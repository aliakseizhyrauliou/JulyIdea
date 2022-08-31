namespace JulyIdea.Services.ChainElementsAPI.DbStuff.Models
{
    public class ChainElement : BaseModel
    {
        public long RootIdeaId { get; set; }
        public long RootIdeaOwnerId { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime DateOfCreating { get; set; }
    }
}
