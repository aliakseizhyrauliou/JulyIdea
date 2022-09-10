using JulyIdea.Services.GroupsAPI.DbStuff;
using JulyIdea.Services.GroupsAPI.DbStuff.Models;

namespace JulyIdea.Services.GroupsAPI.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }
    }
}
