using AutoMapper.Configuration.Annotations;
using JulyIdea.Services.GroupsAPI.DbStuff.Models;

namespace JulyIdea.Services.GroupsAPI.DbStuff
{
    public class DbSeed : IDbSeed
    {
        private ApplicationDbContext _dbContext;

        public DbSeed(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            var group = new Group();
            if (!_dbContext.Groups.Any())
            {
                group = new Group()
                {
                    Name = "Find people",
                    Description = "Make Ideas",
                    MembersCount = 0
                };
                _dbContext.Groups.Add(group);
                _dbContext.SaveChanges();
            }
            if (!_dbContext.GroupUsers.Any()) 
            {
                var GroupUser = new GroupUser()
                {
                    GroupId = group.Id,
                    UserId = 1
                };

                _dbContext.GroupUsers.Add(GroupUser);
                _dbContext.SaveChanges();

            }

        }
    }
}
