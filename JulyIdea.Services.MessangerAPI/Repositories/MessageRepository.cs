using JulyIdea.Services.MessangerAPI.DbStuff;
using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace JulyIdea.Services.MessangerAPI.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public List<Tuple<string, long>> GetUsersIdFormUserDialogs(long userId)
        {
            var resultDialogs = new List<DialogViewModel>();
            var usersIdUserSend = _dbSet.Where(x => x.SenderId == userId)
                    .Select(x => new Tuple<string, long>(x.ReceiverUserName, x.ReceiverId)).Distinct().ToList();

            var userIdUserReceive = _dbSet.Where(x => x.ReceiverId == userId)
                .Select(x => new Tuple<string, long>(x.SenderUserName, x.SenderId)).Distinct().ToList();

            var dialogsUsersId = userIdUserReceive.Union(usersIdUserSend).ToList();

            return dialogsUsersId;
        }

        public Message GetLastMessageOfTwoUser(long firstUserId, long secondUserId) 
        {
            var sqlParamsFirst = new SqlParameter("@firstUserId", firstUserId);
            var sqlParamsSecond = new SqlParameter("@secondUserId", secondUserId);
            var query = "SELECT TOP 1 * " +
                "FROM Messages " +
                "WHERE SenderId = @firstUserId  AND ReceiverId = @secondUserId " +
                "OR SenderId = @secondUserId AND ReceiverId = @firstUserId " +
                "ORDER BY DateOfSending DESC ";

            var message = _dbSet.FromSqlRaw(query, sqlParamsFirst, sqlParamsSecond).First();

            return message;
        }

        public List<Message> GetMessagesOfTwoUser(long userOneId, long userTwoId)
        {
            var userOneIdParam = new SqlParameter("@userOne", userOneId);
            var userTwoParam = new SqlParameter("@userTwo", userTwoId);

            var query = "SELECT * FROM Messages" +
                " WHERE ReceiverId = @userOne AND SenderId = @userTwo OR " +
                "ReceiverId = @userTwo AND SenderId = @userOne ORDER BY DateOfSending";

            var messages = _dbSet.FromSqlRaw(query, userOneIdParam, userTwoParam).ToList();


            return messages;
        }
    }
}
