using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NetFilmx_Storage.Entities;
using System.IO;

namespace NetFilmx_Storage
{
    public class NetFilmxDbContext : DbContext
    {
        public NetFilmxDbContext(DbContextOptions<NetFilmxDbContext> options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VideoTag> VideoTags { get; set; }
        public DbSet<VideoSeries> VideoSeries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Series> Series { get; set; }

        // OnConfiguring method removed,, configuration handeld by factory

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class NetFilmxDbContextFactory : IDesignTimeDbContextFactory<NetFilmxDbContext>
    {
        public NetFilmxDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create DbContextOptionsBuilder and configure it
            var optionsBuilder = new DbContextOptionsBuilder<NetFilmxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "NetFilmx"));

            // Create and return DbContext instance
            return new NetFilmxDbContext(optionsBuilder.Options);
        }
    }
}
