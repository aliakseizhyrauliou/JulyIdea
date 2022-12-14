using AutoMapper;
using JulyIdea.Services.IdeasAPI.AuthAttributes;
using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using JulyIdea.Services.IdeasAPI.Repositories;
using JulyIdea.Services.IdeasAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
        public List<IdeaViewModel> GetPortionOfIdeas(int groupNumber) 
        {
            var dbIdeas = _ideasRepository.GetPortionOfIdeas(groupNumber);
            var ideasViewModel = _mapper.Map<List<IdeaViewModel>>(dbIdeas);

            if (User.Identity.IsAuthenticated) 
            {
                var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
                _ideasRepository.FillIsLikedByCurrentUser(ideasViewModel, userId);
            }
            BuildIdeasLessDesc(ideasViewModel);
            return ideasViewModel; 
        }

        [HttpGet]
        [Authorize]
        public async Task<List<IdeaViewModel>> GetAllIdeas()
        {
            var dbIdeas = await _ideasRepository.GetAll();
            var ideasViewModels = _mapper.Map<List<IdeaViewModel>>(dbIdeas);
            BuildIdeasLessDesc(ideasViewModels);
            return ideasViewModels;
        }

        [HttpGet]
        public async Task<List<IdeaViewModel>> GetIdeaByName(string name)
        {
            if (name == null) 
            {
                return null;
            }
            var ideas = await _ideasRepository.GetByName(name);
            var ideasViewModels = _mapper.Map<List<IdeaViewModel>>(ideas);
            BuildIdeasLessDesc(ideasViewModels);


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
                StackFullString = model.StackFullString,
                IsInGroup = model.IsInGroup,
                GroupId = model.IsInGroup ? model.GroupId : 0,//if idea in group
                Category = model.Category
            };

            await _ideasRepository.Save(idea);

            return _mapper.Map<IdeaViewModel>(idea);
        }

        [HttpGet]
        [Authorize]
        //[IdeaOwner] в таком случае код проще, но лишний раз в базу лезем (??)
        public async Task<bool> DeleteIdea(long ideaId) 
        {
            //Bad
            Roles _roles = new Roles();
            var roles = HttpContext.User.Claims?.SingleOrDefault(x => x.Type == "Role").Value;
            bool successful = Enum.TryParse(roles, out _roles);
            var check = _roles.HasFlag(Roles.Admin);
            if (!(successful && _roles.HasFlag(Roles.Admin)))//Check if admin
            {
                var ideaDb = await _ideasRepository.GetById(ideaId);
                var userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                if (ideaDb.UserId != userId) //Only idea owner or admin can delete idea
                {
                    return false;
                }
            }

            try
            {
                await _ideasRepository.Remove(ideaId);
            }
            catch
            {
                return false;
            }

            return true;
        }

        [HttpPut]
        [Authorize]
        public async Task<IdeaViewModel> UpdateIdea(IdeaViewModel ideaViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
                if (ideaViewModel.UserId != userId) 
                {
                    //Is't owner of idea
                    return null;
                }
                var mapIdeaDbModel = _mapper.Map<Idea>(ideaViewModel);
                var dbIdea = await _ideasRepository.Save(mapIdeaDbModel);

                return _mapper.Map<IdeaViewModel>(dbIdea);
            }

            return null;
        }

        [HttpGet]
        public List<IdeaViewModel> GetIdeasByUserId(long userId) 
        {
            var dbIdeas =  _ideasRepository.GetIdeasByUserId(userId);
            var ideasViewModel = _mapper.Map<List<IdeaViewModel>>(dbIdeas);

            if (User.Identity.IsAuthenticated)
            {
                var currentUserId = int.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
                _ideasRepository.FillIsLikedByCurrentUser(ideasViewModel, currentUserId);
            }

            BuildIdeasLessDesc(ideasViewModel);
            return ideasViewModel;
        }

        [HttpGet]
        public List<IdeaViewModel> GetGroupIdeas(long groupId) 
        {
            var dbIdeas = _ideasRepository.GetGroupIdea(groupId);
            return _mapper.Map<List<IdeaViewModel>>(dbIdeas);

        }

        [HttpGet]
        [Authorize]
        public async Task<IdeaViewModel> AddLike(long ideaId) 
        {
            var userId = long.Parse(User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            return _mapper.Map<IdeaViewModel>(await _ideasRepository.AddLike(ideaId, userId));
        }

        [HttpGet]
        [Authorize]
        public async Task<IdeaViewModel> RemoveLike(long ideaId)
        {
            var userId = long.Parse(User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            return _mapper.Map<IdeaViewModel>(await _ideasRepository.RemoveLike(ideaId, userId));
        }

        //Aditional method
        private List<IdeaViewModel> BuildIdeasLessDesc(List<IdeaViewModel> ideaViewModels) 
        {
            ideaViewModels.ForEach(idea =>
            {
                if (idea.Description.Length > 300)
                {
                    idea.Description = idea.Description.Substring(0, 300) + "...";
                }
            });

            return ideaViewModels;
        }

        

    }
}
