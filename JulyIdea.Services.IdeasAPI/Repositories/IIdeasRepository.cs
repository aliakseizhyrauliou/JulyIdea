using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using JulyIdea.Services.IdeasAPI.ViewModels;

namespace JulyIdea.Services.IdeasAPI.Repositories
{
    public interface IIdeasRepository : IBaseRepository<Idea>
    {
        List<Idea> GetPortionOfIdeas(int groupNumber);
        IEnumerable<Idea> GetIdeasByUserId(long userId);
        Task<IEnumerable<Idea>> GetByName(string name);
        IEnumerable<Idea> GetGroupIdea(long groupId);
        Task<Idea> AddLike(long ideaId, long userId);
        Task<Idea> RemoveLike(long ideaId, long userId);
        public List<IdeaViewModel> FillIsLikedByCurrentUser(List<IdeaViewModel> ideas, long currentUserId);
    }
}
