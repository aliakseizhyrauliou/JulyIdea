namespace JulyIdea.Services.GroupsAPI.ViewModels
{
    public class GroupViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MembersCount { get; set; }
        public bool IsCurrentUserMember { get; set; }
    }
}
