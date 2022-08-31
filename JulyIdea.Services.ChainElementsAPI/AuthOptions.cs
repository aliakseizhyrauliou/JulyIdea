using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JulyIdea.Services.ChainElementsAPI
{
    public class AuthOptions
    {
        public const string ISSUER = "JulyIdea.AuthService";
        public const string AUDIENCE = "July.Services";
        const string KEY = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
