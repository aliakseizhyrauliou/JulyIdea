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
            if (!_dbContext.Groups.Any())
            {
                var group = new Group()
                {
                    Name = "Find people",
                    Description = "Make Ideas",
                    MembersCount = 0
                };
                _dbContext.Groups.Add(group);
                _dbContext.SaveChanges();

            }

        }
    }
}
