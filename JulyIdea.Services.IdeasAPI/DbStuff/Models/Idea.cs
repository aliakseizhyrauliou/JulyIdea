using JulyIdea.Services.IdeasAPI.DbStuff.Models.Enums;

namespace JulyIdea.Services.IdeasAPI.DbStuff.Models
{
    public class Idea : BaseModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StackFullString { get; set; }
        public IdeaCategory Category { get; set; }
        public bool IsInGroup { get; set; }
        public long GroupId { get; set; }
    }
}
