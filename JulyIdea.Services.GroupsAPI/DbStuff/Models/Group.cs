namespace JulyIdea.Services.GroupsAPI.DbStuff.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MembersCount { get; set; }  

    }
}
