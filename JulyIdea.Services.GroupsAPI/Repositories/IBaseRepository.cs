using JulyIdea.Services.GroupsAPI.DbStuff.Models;

namespace JulyIdea.Services.GroupsAPI.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(long id);
        Task<List<T>> GetAll();
        Task<T> Save(T dbModel);
        void Remove(T dbModel);
        Task Remove(long id);
        Task<bool> AnyAsync();
        bool Any();
        void SaveList(IEnumerable<T> dbModelsList);

    }
}
