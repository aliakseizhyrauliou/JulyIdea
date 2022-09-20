using JulyIdea.Services.MessangerAPI.DbStuff.Models;

namespace JulyIdea.Services.MessangerAPI.DbStuff
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
            if (!_dbContext.Messages.Any())
            {
                var message = new Message()
                {
                    SenderId = 1,
                    ReceiverId = 4,
                    DateOfSending = DateTime.Now,
                    IsViewed = false,
                    Text = "Hello!"
                };
                _dbContext.Messages.Add(message);
                _dbContext.SaveChanges();

            }

        }
    }
}
