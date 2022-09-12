using AutoMapper;
using JulyIdea.Services.GroupsAPI.Repositories;
using JulyIdea.Services.GroupsAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace JulyIdea.Services.GroupsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupUserRepository _groupUserRepository;
        public GroupsController(IMapper mapper,
            IGroupRepository groupRepository,
            IGroupUserRepository groupUserRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
            _groupUserRepository = groupUserRepository; 
        }

        [HttpGet]
        public async Task<List<GroupViewModel>> GetAll() 
        {
            var groups = await _groupRepository.GetAll();
            return _mapper.Map<List<GroupViewModel>>(groups);
        }

        [HttpGet]
        public List<GroupUserViewModel> GetMembersByGroupId(long groupId) 
        {
            var members = _groupUserRepository.GetMembersOfGroup(groupId);
            return _mapper.Map<List<GroupUserViewModel>>(members);
        }

        [HttpGet]
        [Authorize]
        public async Task<GroupUserViewModel> JoinGroup(long groupId) 
        {
            var userId = long.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var joinResult = await _groupUserRepository.JoinGroup(userId, groupId);

            return _mapper.Map<GroupUserViewModel>(joinResult);
        }



    }
}
