using JulyIdea.Services.GroupsAPI.DbStuff;
using JulyIdea.Services.GroupsAPI.DbStuff.Models;

namespace JulyIdea.Services.GroupsAPI.Repositories
{
    public class GroupUserRepository : BaseRepository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public  List<GroupUser> GetMembersOfGroup(long groupId) 
        {
            return _dbSet.Where(x => x.GroupId == groupId).ToList();
        }

        public async Task<GroupUser> JoinGroup(long userId, long groupId) 
        {
            if (!_dbSet.Any(x => x.GroupId == groupId && x.UserId == userId) && 
                _dbSet.Any(x => x.GroupId == groupId)) 
            {
                var groupUser = new GroupUser()
                {
                    GroupId = groupId,
                    UserId = userId
                };

                await Save(groupUser);

                return groupUser;
            }

            return null;

        }

    }
}
