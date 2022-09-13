using JulyIdea.Services.AuthAPI.DbStuff;
using JulyIdea.Services.AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.AuthAPI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        public UserRepository(ApplicationDbContex dbContex) : base(dbContex)
        {

        }

        public async Task<User> CredentialsIdentification(string email, string passwordHash)
        {
            return await _dbSet
                .SingleOrDefaultAsync(user => user.Email == email &&
                user.PasswordHash == passwordHash);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserInfoByUserName(string userName)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
