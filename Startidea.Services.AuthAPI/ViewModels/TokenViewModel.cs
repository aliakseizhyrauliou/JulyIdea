using JulyIdea.Services.AuthAPI.Models.Enums;

namespace JulyIdea.Services.AuthAPI.ViewModels
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public Roles UserRoles { get; set; }

    }
}
