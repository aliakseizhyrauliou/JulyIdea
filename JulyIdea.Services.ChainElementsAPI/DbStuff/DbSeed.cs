using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;

namespace JulyIdea.Services.ChainElementsAPI.DbStuff
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
            if (!_dbContext.ChainElements.Any())
            {
                var chain = new ChainElement()
                {
                    OwnerId = 8,
                    Name = "Lets create mobile app",
                    Description = "Some info about upgrading root idea",
                    isConfirmed = false,
                    RootIdeaId = 4,
                    RootIdeaOwnerId = 8,
                    DateOfCreating = DateTime.Now,
                };

                _dbContext.ChainElements.Add(chain);
                _dbContext.SaveChanges();

            }

        }
    }
}
