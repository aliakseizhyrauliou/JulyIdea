using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Models.Enums;
using JulyIdea.Services.AuthAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JulyIdea.AuthAPI.Tests
{
    public class TokenServiceTests
    {
        private static User userMock = new User()
        {
            Id = 4,
            Roles = Roles.Admin,
            FirstName = "Alex"
        };

        private static List<Claim> userClaimns = new List<Claim>() {
                    new Claim("Id", userMock.Id.ToString()),
                    new Claim(ClaimTypes.Role, userMock.Roles.ToString()),
                    new Claim("Name", userMock.FirstName) };

        [Fact]
        public void IsCorrectUserClaims() 
        {
            var service = new TokenService();
            var result = service.GetUserClaims(userMock);

            Assert.Contains(result, c => c.Type == "Id");
            Assert.Contains(result, c => c.Type == ClaimTypes.Role);
            Assert.Contains(result, c => c.Type == "Name");
        }


        [Fact]
        public void IsClaimValuesCorrect() 
        {
            var service = new TokenService();
            var result = service.GetUserClaims(userMock);

            Assert.Equal(result.SingleOrDefault(x => x.Type == "Id")?.Value, userMock.Id.ToString());
            Assert.Equal(result.SingleOrDefault(x => x.Type == ClaimTypes.Role)?.Value, userMock.Roles.ToString());
            Assert.Equal(result.SingleOrDefault(x => x.Type == "Name")?.Value, userMock.FirstName.ToString());
        }

        [Fact]
        public void GeneratedAccessTokenNotNull() 
        {
            var service = new TokenService();
            var result = service.GenerateAccessToken(userClaimns);

            Assert.NotNull(result); 
        }

        [Fact]
        public void GeneratedRefreshTokenNotNull() 
        {
            var service = new TokenService();
            var result = service.GenerateRefreshToken(userClaimns);

            Assert.NotNull(result);
        }

        [Fact]
        public void IsGenerateTokensCorrectOutput() 
        {
            var service = new TokenService();
            var result = service.GenerateTokens(userMock);

            Assert.NotNull(result);
            Assert.Equal(result.UserName, userMock.UserName);
            Assert.Equal(result.UserId, userMock.Id);
            Assert.Equal(result.UserRoles, userMock.Roles);
        }
    }
}
