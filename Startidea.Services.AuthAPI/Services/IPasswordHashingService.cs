namespace JulyIdea.Services.AuthAPI.Services
{
    public interface IPasswordHashingService
    {
        string GetHashOfPassword(string password, byte[] salt);
        byte[] GenerateSalt();

    }
}
