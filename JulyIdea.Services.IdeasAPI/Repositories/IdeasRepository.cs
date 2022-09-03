using JulyIdea.Services.IdeasAPI.DbStuff;
using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.IdeasAPI.Repositories
{
    public class IdeasRepository : BaseRepository<Idea>, IIdeasRepository
    {
        public IdeasRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public async Task<IEnumerable<Idea>> GetByName(string name)
        {
            return await _dbSet.Where(idea => idea.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public  IEnumerable<Idea> GetIdeasByUserId(long userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }
    }
}
