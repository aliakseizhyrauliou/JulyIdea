using AutoMapper;
using JulyIdea.Services.GroupsAPI.Repositories;
using JulyIdea.Services.GroupsAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JulyIdea.Services.GroupsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository; 
        public GroupsController(IMapper mapper,
            IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<List<GroupViewModel>> GetAll() 
        {
            var groups = await _groupRepository.GetAll();
            return _mapper.Map<List<GroupViewModel>>(groups);
        }

    }
}
