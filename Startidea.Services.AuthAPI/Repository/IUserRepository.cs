using JulyIdea.Services.AuthAPI.Models;

namespace JulyIdea.Services.AuthAPI.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> CredentialsIdentification(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
