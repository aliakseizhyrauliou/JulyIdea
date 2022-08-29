using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.Models.Enums;
using JulyIdea.Services.AuthAPI.Repository;
using JulyIdea.Services.AuthAPI.Services.IService;

namespace JulyIdea.Services.AuthAPI.DbStuff
{
    public class DbSeed : IDbSeed
    {
        private ApplicationDbContex _dbContext;
        private IPasswordHashingService _passwordHashing;

        public DbSeed(ApplicationDbContex dbContext,
            IPasswordHashingService passwordHashing)
        {
            _dbContext = dbContext;
            _passwordHashing = passwordHashing;
        }

        public void Initialize() 
        {
            if (!_dbContext.Users.Any()) 
            {
                var salt = _passwordHashing.GenerateSalt();
                var password = _passwordHashing.GetHashOfPassword("admin", salt);

                var user = new User()
                {
                    UserName = "admin",
                    FirstName = "Alexey",
                    LasName = "Zhurauliou",
                    Age = 20,
                    Email = "admin",
                    Roles = Roles.Admin,
                    Salt = salt,
                    PasswordHash = password
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }

        }

    }
}
