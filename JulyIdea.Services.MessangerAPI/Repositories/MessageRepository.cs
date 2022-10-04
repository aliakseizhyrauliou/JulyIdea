using JulyIdea.Services.MessangerAPI.DbStuff;
using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public List<long> GetUsersIdFormUserDialogs(long userId)
        {
            var resultDialogs = new List<DialogViewModel>();
            var usersIdUserSend = _dbSet.Where(x => x.SenderId == userId)
                    .Select(x => x.ReceiverId).Distinct();

            var userIdUserReceive = _dbSet.Where(x => x.ReceiverId == userId)
                .Select(x => x.SenderId).Distinct();

            var dialogsUsersId = userIdUserReceive.Union(usersIdUserSend).ToList();

            return dialogsUsersId;
        }

        public Message GetLastMessageOfTwoUser(long firstUserId, long secondUserId) 
        {
            var message = _dbSet.Where(x => x.ReceiverId == firstUserId && x.SenderId == secondUserId ||
                x.SenderId == firstUserId && x.ReceiverId == secondUserId)
                .OrderByDescending(x => x.DateOfSending)
                .First();

            return message;
        }

        public List<Message> GetMessagesOfTwoUser(long userOneId, long userTwoId)
        {
            var messages = _dbSet.Where(x => x.SenderId == userOneId && x.ReceiverId == userTwoId ||
                x.ReceiverId == userOneId && x.SenderId == userTwoId).OrderBy(x => x.DateOfSending).ToList();

            return messages;
        }
    }
}
