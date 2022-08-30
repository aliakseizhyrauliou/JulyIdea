using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.IdeasAPI.DbStuff
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Idea>(x =>
            {
                x.HasMany(u => u.ChainElements)
                .WithOne(p => p.RootIdea);
            });
        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<ChainElement> ChainElements { get; set; }
    }
}
