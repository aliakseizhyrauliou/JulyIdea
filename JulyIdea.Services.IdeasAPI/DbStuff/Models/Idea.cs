namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class Idea : BaseModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StackFullString { get; set; }
    }
}
