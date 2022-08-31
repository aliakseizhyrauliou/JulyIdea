using JulyIdea.Services.ChainElementsAPI.DbStuff;
using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;

namespace JulyIdea.Services.ChainElementsAPI.Repository
{
    public class ChainRepository : BaseRepository<ChainElement>, IChainElementRepository
    {
        public ChainRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }
    }
}
