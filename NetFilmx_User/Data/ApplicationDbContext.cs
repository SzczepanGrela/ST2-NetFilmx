using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetFilmx_User.Models;

namespace NetFilmx_User.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the ApplicationUser entity
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("AspNetUsers"); // Keep the default Identity table name
                
                // Index on NetFilmxUserId for fast lookups
                entity.HasIndex(u => u.NetFilmxUserId).IsUnique(false);
                
                // Index on email for performance
                entity.HasIndex(u => u.Email).IsUnique(false);
                
                // Index on display name
                entity.HasIndex(u => u.DisplayName).IsUnique(false);
            });
        }
    }
}
