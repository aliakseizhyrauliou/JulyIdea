using JulyIdea.Services.MessangerAPI.DbStuff;
using JulyIdea.Services.MessangerAPI.DbStuff.Models;

namespace JulyIdea.Services.MessangerAPI.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }
    }
}
