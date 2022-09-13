using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Services.IService;
using JulyIdea.Services.AuthAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace JulyIdea.Services.AuthAPI.Services
{
    public class TokenService : ITokenService
    {
        private const int _accessTokenExpiresMinutes = 60;
        private const int _refreshTokenExpiresDays = 30;

        public TokenViewModel GenerateTokens(User candidateForTokens)
        {
            var claims = GetUserClaims(candidateForTokens);
            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken(claims);

            var tokenResponce = new TokenViewModel()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserName = candidateForTokens.UserName,
                UserId = candidateForTokens.Id,
                UserRoles = candidateForTokens.Roles
            };

            return tokenResponce;

        }

        public string GenerateAccessToken(IEnumerable<Claim> userClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: userClaims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_accessTokenExpiresMinutes)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken(IEnumerable<Claim> userClaims)
        {
            var id = userClaims.Where(claim => claim.Type == "Id");
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: userClaims.Where(claim => claim.Type == "Id"),
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_refreshTokenExpiresDays)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public IEnumerable<Claim> GetUserClaims(User candidateForTokens)
        {
            return new List<Claim>() {
                    new Claim("Id", candidateForTokens.Id.ToString()),
                    new Claim(ClaimTypes.Role, candidateForTokens.Roles.ToString()),
                    new Claim("Name", candidateForTokens.FirstName),
                };

        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,
                ValidIssuer = AuthOptions.ISSUER,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidAudience = AuthOptions.AUDIENCE,

            };


            SecurityToken validatedToken;

            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);

            }
            catch (SecurityTokenSignatureKeyNotFoundException)
            {
                return false;
            }

            return true;
        }
    }
}
