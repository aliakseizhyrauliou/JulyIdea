using AutoMapper;
using JulyIdea.Services.AuthAPI.Repository;
using JulyIdea.Services.AuthAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JulyIdea.Services.AuthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UsersController(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<UserViewModel> GetUserInfo(long userId)
        {
            var user = await _userRepository.GetById(userId);
            return _mapper.Map<UserViewModel>(user);
        }

        [HttpGet]
        [Authorize]
        public async Task<UserViewModel> GetCurrentUserInfo()
        {
            var userId = long.Parse(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var user = await _userRepository.GetById(userId);
            return _mapper.Map<UserViewModel>(user);
        }

        [HttpGet]
        public async Task<List<UserViewModel>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
