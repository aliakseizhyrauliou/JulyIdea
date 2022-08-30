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
        public IdeasController(IIdeasRepository ideasRepository)
        {
            _ideasRepository = ideasRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<IdeaViewModel>> GetAllIdeas() 
        {
            var ideas = await _ideasRepository.GetAll();
            var res = ideas.Select(u => new IdeaViewModel()
            {
                UserId = u.UserId,
                Stack = u.Stack.Select(q => q.Technology).ToList(),
                ChainElements = u.ChainElements.Select(c => new ChainElement() { Id = c.Id, Name = c.Name, Descriptions = c.Descriptions, IsConfirmed = c.IsConfirmed }).ToList(),
                Name = u.Name,
                Description = u.Description
            }).ToList();

            return res;
        }
    }
}
