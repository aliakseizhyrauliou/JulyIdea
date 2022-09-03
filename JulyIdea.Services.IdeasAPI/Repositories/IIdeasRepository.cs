using JulyIdea.Services.IdeasAPI.DbStuff.Models;

namespace JulyIdea.Services.IdeasAPI.Repositories
{
    public interface IIdeasRepository : IBaseRepository<Idea>
    {
        IEnumerable<Idea> GetIdeasByUserId(long userId);
        Task<IEnumerable<Idea>> GetByName(string name);
    }
}
