namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class Stack : BaseModel
    {
        public virtual Idea Idea { get; set; }
        public string Technology { get; set; }
    }
}
