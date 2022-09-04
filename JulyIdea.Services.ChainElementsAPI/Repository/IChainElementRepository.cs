using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;

namespace JulyIdea.Services.ChainElementsAPI.Repository
{
    public interface IChainElementRepository : IBaseRepository<ChainElement>
    {
        List<ChainElement> GetElementsByIdeaId(long ideaId, bool onlyApproved);
    }
}
