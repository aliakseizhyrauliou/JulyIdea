namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class ChainElement : BaseModel
    {
        public long UserId { get; set; }
        public virtual Idea RootIdea { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
