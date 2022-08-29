namespace JulyIdea.Services.AuthAPI.Services.IService
{
    public interface IPasswordHashingService
    {
        string GetHashOfPassword(string password, byte[] salt);
        byte[] GenerateSalt();

    }
}
