using JulyIdea.Services.GroupsAPI.DbStuff.Models;

namespace JulyIdea.Services.GroupsAPI.Repositories
{
    public interface IGroupUserRepository : IBaseRepository<GroupUser>
    {
        List<GroupUser> GetMembersOfGroup(long groupId);
        Task<GroupUser> JoinGroup(long userId, long groupId);
        int MemberCount(long groupId);

    }
}
