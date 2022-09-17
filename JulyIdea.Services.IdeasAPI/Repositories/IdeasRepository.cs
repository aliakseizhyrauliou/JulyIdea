﻿using JulyIdea.Services.IdeasAPI.DbStuff;
using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.IdeasAPI.Repositories
{
    public class IdeasRepository : BaseRepository<Idea>, IIdeasRepository
    {
        public IdeasRepository(ApplicationDbContext dbContex) : base(dbContex)
        {
        }

        public async Task<IEnumerable<Idea>> GetByName(string name)
        {
            return await _dbSet.Where(idea => idea.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public  IEnumerable<Idea> GetIdeasByUserId(long userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }

        public IEnumerable<Idea> GetGroupIdea(long groupId) 
        {
            return _dbSet.Where(x => x.IsInGroup && x.GroupId == groupId);
        }

        public async Task<Idea> AddLike(long ideaId, long userId)
        {
            try
            {
                var ideaDb = await GetById(ideaId);

                if (ideaDb != null && 
                    !ideaDb.Likes.Any(x => x.UserId == userId))
                {
                    var like = new IdeaLike()
                    {
                        IdeaId = ideaDb.Id,
                        UserId = userId
                    };

                    ideaDb.Likes.Add(like);

                    await Save(ideaDb);

                    return ideaDb;
                }

                return null;
            }
            catch (Exception) 
            {
                return null;
            }

        }

        public async Task<Idea> RemoveLike(long ideaId, long userId)
        {
            try
            {
                var idea = await GetById(ideaId);
                if (idea != null &&
                    idea.Likes.Any(x => x.UserId == userId))
                {
                    var ideaToDelete = idea.Likes.SingleOrDefault(x => x.UserId == userId);
                    idea.Likes.Remove(ideaToDelete);
                    await Save(idea);
                    return idea;
                }
                return null;
            }
            catch (Exception) 
            {
                return null;
            }
        }
    }
}
