using JulyIdea.Services.AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JulyIdea.Services.AuthAPI.DbStuff
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
