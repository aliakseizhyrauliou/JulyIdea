﻿using JulyIdea.Services.IdeasAPI.DbStuff.Models;

namespace JulyIdea.Services.IdeasAPI.DbStuff
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
            if (!_dbContext.Ideas.Any())
            {
                var idea = new Idea()
                {
                    Name = "Create Idea App",
                    Description = "Idea app with chain",
                    UserId = 8
                };
                _dbContext.Ideas.Add(idea);
                _dbContext.SaveChanges();

                var chainElement = new ChainElement()
                {
                    Descriptions = "Create mobile version",
                    IsConfirmed = false,
                    Name = "Mobile",
                    RootIdea = idea,
                    UserId = 8
                };


                var stack = new List<Stack>
                {
                    new Stack()
                    {
                        Idea = idea,
                        Technology = "Angular"
                    },
                    new Stack()
                    {
                        Idea = idea,
                        Technology = "ASP.NET"
                    }
                };

                idea.Stack = stack;
                _dbContext.ChainElements.Add(chainElement);
                idea.ChainElements.Add(chainElement);
                _dbContext.SaveChanges();

            }

        }
    }
}