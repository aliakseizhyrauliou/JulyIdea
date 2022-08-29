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

        public  IEnumerable<Idea> GetIdeasByUserId(long userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }
    }
}
