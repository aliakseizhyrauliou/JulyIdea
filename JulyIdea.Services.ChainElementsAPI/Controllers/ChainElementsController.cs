using AutoMapper;
using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;
using JulyIdea.Services.ChainElementsAPI.Repository;
using JulyIdea.Services.ChainElementsAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JulyIdea.Services.ChainElementsAPI.Controllers
{
    [Route("api/chain/[action]")]
    [ApiController]
    public class ChainElementsController : ControllerBase
    {
        private readonly IChainElementRepository _chainRepository;
        private readonly IMapper _mapper;

        public ChainElementsController(IChainElementRepository chainElement,
            IMapper mapper)
        {
            _chainRepository = chainElement;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ChainElementViewModel>> GetAllChains() 
        {
            var chainsDb = await _chainRepository.GetAll();
            return _mapper.Map<List<ChainElementViewModel>>(chainsDb);
        }

        [HttpGet]
        public List<ChainElementViewModel> GetChainElementsByIdeaId(long ideaId, bool onlyApproved = false) 
        {
            var elements = _chainRepository.GetElementsByIdeaId(ideaId, onlyApproved);
            return _mapper.Map<List<ChainElementViewModel>>(elements);
        }

        [HttpGet]
        public async Task<ChainElementViewModel> GetChainById(long chainId) 
        {
            var chain = await _chainRepository.GetById(chainId);
            return _mapper.Map<ChainElementViewModel>(chain);
        }

        [HttpPost]
        [Authorize]
        public async Task<ChainElementViewModel> CreateChainElement(ChainElementViewModel chain) 
        {
            if (ModelState.IsValid) 
            {
                var chainDb = await _chainRepository.Save(_mapper.Map<ChainElement>(chain));
                return _mapper.Map<ChainElementViewModel>(chainDb);
            }

            return null;
        }

        [HttpDelete]
        [Authorize]

        public async Task<bool> DeleteChainElement(long chainId) 
        {
            var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var chainDb = await _chainRepository.GetById(chainId);

            if (chainDb.OwnerId != userId) 
            {
                return false; 
            }

            try 
            {
                _chainRepository.Remove(chainDb);
            }
            catch 
            {
                return false;
            }

            return true;
        }

        [HttpGet]
        [Authorize]
        public async Task<ChainElementViewModel> ConfirmChainElement(long chaninId) 
        {
            var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var chainDb = await _chainRepository.GetById(chaninId);
            if (chainDb.RootIdeaOwnerId != userId) 
            {
                return null;
            }

            chainDb.isConfirmed = true;
            var chain = await _chainRepository.Save(chainDb);
            return _mapper.Map<ChainElementViewModel>(chain);
        }

    }
}
