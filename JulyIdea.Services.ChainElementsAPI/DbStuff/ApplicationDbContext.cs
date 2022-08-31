using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.ChainElementsAPI.DbStuff
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ChainElement> ChainElements { get; set; } 
    }
}
