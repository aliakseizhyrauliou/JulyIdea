using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.MessangerAPI.DbStuff
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

    }
}
