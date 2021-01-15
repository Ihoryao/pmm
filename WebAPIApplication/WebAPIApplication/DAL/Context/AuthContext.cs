using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPIApplication.Models
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext()
        {
            Database.EnsureCreated();
        }

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=User;Username=postgres;Password=2402076");
        }
    }
}