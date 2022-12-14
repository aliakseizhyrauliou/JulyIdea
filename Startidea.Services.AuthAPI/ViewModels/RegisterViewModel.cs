using System.ComponentModel.DataAnnotations;

namespace JulyIdea.Services.AuthAPI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }

    }
}
