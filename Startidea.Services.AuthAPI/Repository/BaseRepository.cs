using JulyIdea.Services.AuthAPI.DbStuff;
using JulyIdea.Services.AuthAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.AuthAPI.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContex _dbContex;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
            _dbSet = _dbContex.Set<T>();
        }

        public async Task<bool> Any()
        {
            return await _dbSet.AnyAsync();
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

        public async void Remove(T dbModel)
        {
            _dbSet.Remove(dbModel);
            await _dbContex.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            _dbSet.Remove(await GetById(id));
            await _dbContex.SaveChangesAsync();
        }

        public async Task Save(T dbModel)
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
        }

        public void SaveList(IEnumerable<T> dbModelsList)
        {
            dbModelsList.ToList().ForEach(async x => await Save(x));
        }
    }
}
