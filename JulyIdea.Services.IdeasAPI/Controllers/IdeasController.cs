using AutoMapper;
using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using JulyIdea.Services.IdeasAPI.Repositories;
using JulyIdea.Services.IdeasAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JulyIdea.Services.IdeasAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private IIdeasRepository _ideasRepository;
        private readonly IMapper _mapper;
        public IdeasController(IIdeasRepository ideasRepository,
            IMapper mapper)
        {
            _ideasRepository = ideasRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<IdeaViewModel>> GetAllIdeas() 
        {
            var dbIdeas = await _ideasRepository.GetAll();
            var ideasViewModels = _mapper.Map<List<IdeaViewModel>>(dbIdeas);

            return ideasViewModels;
        }


        [HttpGet]
        public async Task<IdeaViewModel> GetIdeaById(long ideaId) 
        {
            var dbIdea = await _ideasRepository.GetById(ideaId);
            if (dbIdea == null) 
            {
                return null;
            }

            return _mapper.Map<IdeaViewModel>(dbIdea);
        }


        [HttpPost]
        [Authorize]
        public async Task<IdeaViewModel> CreateIdea(IdeaViewModel model)
        {
            var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);

            var idea = new Idea()
            {
                Name = model.Name,
                Description = model.Description,
                UserId = userId,
                StackFullString = model.StackFullString
            };

            await _ideasRepository.Save(idea);

            return _mapper.Map<IdeaViewModel>(idea);
        }


    }
}
