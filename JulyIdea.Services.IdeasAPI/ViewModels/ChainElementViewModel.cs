using JulyIdea.Services.IdeasAPI.DbStuff.Models;

namespace JulyIdea.Services.IdeasAPI.ViewModels
{
    public class ChainElementViewModel
    {
        public long UserId { get; set; }
        public long RootIdeaId { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
