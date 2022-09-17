namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class IdeaLike : BaseModel
    {
        public long UserId { get; set; }
        public long IdeaId { get; set; }
    }
}
