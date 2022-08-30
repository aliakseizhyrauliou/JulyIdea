using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using System.ComponentModel.DataAnnotations;

namespace JulyIdea.Services.IdeasAPI.ViewModels
{
    public class IdeaViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StackFullString { get; set; }

        public List<string> Stack 
        {
            get { return StackFullString.Split(',').ToList(); }
            set
            {
                StackFullString = String.Join(",", value);
            }
        }
        public List<ChainElementViewModel> ChainElements { get; set; } = new List<ChainElementViewModel>();
    }
}
