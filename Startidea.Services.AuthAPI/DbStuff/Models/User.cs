using JulyIdea.Services.AuthAPI.DbStuff.Models;
using JulyIdea.Services.AuthAPI.Models.Enums;

namespace JulyIdea.Services.AuthAPI.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LasName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public int Age { get; set; }
        public string PasswordHash { get; set; }
        public Roles Roles { get; set; }
    }
}
