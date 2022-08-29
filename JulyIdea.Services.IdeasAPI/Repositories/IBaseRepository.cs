using JulyIdea.Services.IdeasAPI.DbStuff.Models;

namespace JulyIdea.Services.IdeasAPI.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(long id);
        Task<List<T>> GetAll();
        Task Save(T dbModel);
        void Remove(T dbModel);
        Task Remove(long id);
        Task<bool> AnyAsync();
        bool Any();
        void SaveList(IEnumerable<T> dbModelsList);

    }
}
