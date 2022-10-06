namespace JulyIdea.Services.MessangerAPI.ViewModels
{
    public class DialogViewModel
    {
        public long OwnerId { get; set; }
        public long UserId { get; set; }
        public MessageViewModel LastMessage { get; set; }
        public string ReceiverFullName { get; set; }
        public string SenderFullName { get; set; }

    }
}
