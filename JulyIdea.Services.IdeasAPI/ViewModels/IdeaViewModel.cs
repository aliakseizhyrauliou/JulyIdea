using JulyIdea.Services.IdeasAPI.DbStuff.Models;

namespace JulyIdea.Services.IdeasAPI.ViewModels
{
    public class IdeaViewModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<string> Stack { get; set; }
        public virtual List<ChainElement> ChainElements { get; set; } = new List<ChainElement>();
    }
}
