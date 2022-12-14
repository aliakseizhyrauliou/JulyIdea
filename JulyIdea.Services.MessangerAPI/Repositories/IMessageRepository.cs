using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        List<Tuple<string, long>> GetUsersIdFormUserDialogs(long userId);
        Message GetLastMessageOfTwoUser(long firstUserId, long secondUserId);

        List<Message> GetMessagesOfTwoUser(long userOneId, long userTwoId);
    }
}
