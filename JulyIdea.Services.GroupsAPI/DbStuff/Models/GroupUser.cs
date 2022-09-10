namespace JulyIdea.Services.GroupsAPI.DbStuff.Models
{
    public class GroupUser : BaseModel
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }
    }
}
