using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        List<long> GetUsersIdFormUserDialogs(long userId);
        Message GetLastMessageOfTwoUser(long firstUserId, long secondUserId);

    }
}
