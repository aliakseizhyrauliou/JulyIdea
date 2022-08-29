namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class Idea : BaseModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  virtual List<Stack> Stack { get; set; }
        public virtual List<ChainElement> ChainElements { get; set; } = new List<ChainElement>();
    }
}
