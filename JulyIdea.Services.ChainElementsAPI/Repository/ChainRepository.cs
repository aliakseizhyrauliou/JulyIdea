using JulyIdea.Services.ChainElementsAPI.DbStuff;
using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;

namespace JulyIdea.Services.ChainElementsAPI.Repository
{
    public class ChainRepository : BaseRepository<ChainElement>, IChainElementRepository
    {
        public ChainRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public List<ChainElement> GetElementsByIdeaId(long ideaId, bool onlyApproved)
        {
            return _dbSet.Where(c => c.RootIdeaId == ideaId && c.isConfirmed == onlyApproved).ToList();
        }
    }
}
