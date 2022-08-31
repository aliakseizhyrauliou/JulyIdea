using JulyIdea.Services.ChainElementsAPI.DbStuff;
using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.ChainElementsAPI.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _dbContex;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
            _dbSet = _dbContex.Set<T>();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }


        public bool Any()
        {
            return _dbSet.Any();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(T dbModel)
        {
            _dbSet.Remove(dbModel);
            _dbContex.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            _dbSet.Remove(await GetById(id));
            await _dbContex.SaveChangesAsync();
        }

        public async Task<T> Save(T dbModel)
        {
            if (dbModel.Id > 0)
            {
                _dbSet.Update(dbModel);
            }
            else
            {
                _dbSet.Add(dbModel);
            }

            await _dbContex.SaveChangesAsync();
            return dbModel;
        }

        public void SaveList(IEnumerable<T> dbModelsList)
        {
            dbModelsList.ToList().ForEach(async x => await Save(x));
        }
    }
}
