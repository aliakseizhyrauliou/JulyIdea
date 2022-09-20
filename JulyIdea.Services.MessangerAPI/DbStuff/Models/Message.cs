namespace JulyIdea.Services.MessangerAPI.DbStuff.Models
{
    public class Message : BaseModel
    {
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime DateOfSending { get; set; }
        public bool IsViewed { get; set; }
    }
}
