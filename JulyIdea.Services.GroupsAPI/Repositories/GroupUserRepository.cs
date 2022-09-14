using JulyIdea.Services.GroupsAPI.DbStuff;
using JulyIdea.Services.GroupsAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.GroupsAPI.Repositories
{
    public class GroupUserRepository : BaseRepository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public  List<GroupUser> GetMembersOfGroup(long groupId) 
        {
            return _dbSet
                .Where(x => x.GroupId == groupId)
                .ToList();
        }

        public async Task<bool> IsSpecificUserMember(long userId, long groupId) 
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.UserId == userId && x.GroupId == groupId) != null;
        }

        public async Task<GroupUser> JoinGroup(long userId, long groupId) 
        {
            if (!_dbSet.Any(x => x.GroupId == groupId && x.UserId == userId) && 
                _dbContex.Groups.Any(x => x.Id == groupId)) 
            {
                var groupUser = new GroupUser()
                {
                    GroupId = groupId,
                    UserId = userId
                };

                await Save(groupUser);



                //*************************************************
                var dbGroup = await _dbContex.Groups
                    .SingleOrDefaultAsync(x => x.Id == groupId);

                if (dbGroup != null) 
                {
                    dbGroup.MembersCount++;
                    _dbContex.Groups.Update(dbGroup);
                    await _dbContex.SaveChangesAsync();
                }
                //*************************************************



                return groupUser;
            }

            return null;

        }

        public async Task<bool> LeaveGroup(long userId, long groupId) 
        {
            try
            {
                var groupUserDb = await _dbSet
                    .SingleOrDefaultAsync(x => x.UserId == userId && x.GroupId == groupId);

                if (groupUserDb == null) 
                {
                    return false;
                }

                _dbContex.Remove(groupUserDb);

                var group = await _dbContex.Groups.SingleOrDefaultAsync(x => x.Id == groupId);
                group.MembersCount--;
                _dbContex.Update(group);
                await _dbContex.SaveChangesAsync();

                return true;

            }
            catch (Exception) 
            {
                return false;
            }
        }

        public int MemberCount(long groupId) 
        {
            return _dbSet
                .Where(x => x.GroupId == groupId)
                .Count();
        }




    }
}
