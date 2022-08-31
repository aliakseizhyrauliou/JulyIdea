namespace JulyIdea.Services.ChainElementsAPI.ViewModels
{
    public class ChainElementViewModel
    {
        public long Id { get; set; }
        public long RootIdeaId { get; set; }
        public long RootIdeaOwnerId { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime DateOfCreating { get; set; }
    }
}
