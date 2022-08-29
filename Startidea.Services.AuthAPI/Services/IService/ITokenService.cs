using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.ViewModels;
using System.Security.Claims;

namespace JulyIdea.Services.AuthAPI.Services.IService
{
    public interface ITokenService
    {

        TokenViewModel GenerateTokens(User candidateForTokens);
        IEnumerable<Claim> GetUserClaims(User candidateForTokens);
        string GenerateAccessToken(IEnumerable<Claim> userClaims);
        string GenerateRefreshToken(IEnumerable<Claim> userClaims);
        bool ValidateRefreshToken(string refreshToken);

    }
}
