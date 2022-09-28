using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JulyIdea.AuthAPI.Tests
{
    public class TokenServiceTests
    {
        private User userMock = new User()
        {
            Id = 4,
            Roles = Roles.Admin,
            FirstName = "Alex"
        };
        public void IsCorrectUserClaims() 
        {

        }

    }
}
