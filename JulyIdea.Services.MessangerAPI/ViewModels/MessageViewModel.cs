using System.ComponentModel.DataAnnotations;

namespace JulyIdea.Services.MessangerAPI.ViewModels
{
    public class MessageViewModel
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        [Required]
        public long ReceiverId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateOfSending { get; set; }
        public bool IsViewed { get; set; }
    }
}
