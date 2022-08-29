using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Repository;
using JulyIdea.Services.AuthAPI.Responce;
using JulyIdea.Services.AuthAPI.Services;
using JulyIdea.Services.AuthAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Startidea.Services.AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private ResponceDto responceDto;
        private IPasswordHashingService _passwordHashingService;
        private ITokenService _tokenService;
        private IUserRepository _userRepository;

        public AuthController(IPasswordHashingService passwordHashingService,
            ITokenService tokenService,
            IUserRepository userRepository)
        {
            responceDto = new ResponceDto();
            _passwordHashingService = passwordHashingService;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ResponceDto> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    responceDto.ErrorMessages.Add("Invalid data");
                    responceDto.IsSuccess = false;
                    return responceDto;
                }

                var salt = _passwordHashingService.GenerateSalt();
                var user = new User()
                {
                    Email = registerViewModel.Email,
                    Salt = salt,
                    PasswordHash = _passwordHashingService.GetHashOfPassword(registerViewModel.Password, salt)
                };

                await _userRepository.Save(user);

                responceDto.Result = user;

                return responceDto;
            }
            catch (Exception ex)
            {
                responceDto.ErrorMessages.Add(ex.Message);
                responceDto.IsSuccess = false;
                return responceDto;
            }
        }

        [HttpPost]
        public async Task<ResponceDto> Login(LoginViewModel loginViewModel) 
        {
            try
            {
                var candidate = await _userRepository.GetByEmail(loginViewModel.Email);
                if (_passwordHashingService.GetHashOfPassword(loginViewModel.Password, candidate.Salt) == candidate.PasswordHash) 
                {
                    var userTokens = _tokenService.GenerateTokens(candidate);
                    responceDto.Result = userTokens;
                    return responceDto;
                }

                responceDto.IsSuccess = false;
                return responceDto;
                
            }
            catch (Exception ex) 
            {
                responceDto.ErrorMessages = new List<string> { ex.Message };
                responceDto.IsSuccess = false;
                return responceDto;
            }
        }

        [HttpGet]
        public  bool RefreshToken(string token)
        {
            return _tokenService.ValidateRefreshToken(token);
        }
    }
}