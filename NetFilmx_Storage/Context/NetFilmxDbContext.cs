using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Context
{
    public class NetFilmxDbContext : DbContext
    {
        public NetFilmxDbContext(DbContextOptions<NetFilmxDbContext> options) : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<VideoPurchase> VideoPurchases { get; set; }
        public DbSet<SeriesPurchase> SeriesPurchases { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ViewHistory> ViewHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many relationships

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .UsingEntity<Dictionary<string, object>>(
                    "VideoTag",
                    j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                    j => j.HasOne<Video>().WithMany().HasForeignKey("VideoId"),
                    j => j.HasKey("TagId", "VideoId"));

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Categories)
                .WithMany(c => c.Videos)
                .UsingEntity<Dictionary<string, object>>(
                    "VideoCategory",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    j => j.HasOne<Video>().WithMany().HasForeignKey("VideoId"),
                    j => j.HasKey("CategoryId", "VideoId"));

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Series)
                .WithMany(s => s.Videos)
                .UsingEntity<Dictionary<string, object>>(
                    "VideoSeries",
                    j => j.HasOne<Series>().WithMany().HasForeignKey("SeriesId"),
                    j => j.HasOne<Video>().WithMany().HasForeignKey("VideoId"),
                    j => j.HasKey("SeriesId", "VideoId"));

            // One-to-Many relationships
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Video)
                .WithMany(v => v.Likes)
                .HasForeignKey(l => l.VideoId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Video)
               .WithMany(v => v.Comments)
               .HasForeignKey(c => c.VideoId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<VideoPurchase>()
                .HasOne(uvp => uvp.User)
                .WithMany(u => u.VideoPurchases)
                .HasForeignKey(uvp => uvp.UserId);

            modelBuilder.Entity<VideoPurchase>()
                .HasOne(uvp => uvp.Video)
                .WithMany(v => v.VideoPurchases)
                .HasForeignKey(uvp => uvp.VideoId);


            modelBuilder.Entity<SeriesPurchase>()
                .HasOne(usp => usp.User)
                .WithMany(u => u.SeriesPurchases)
                .HasForeignKey(usp => usp.UserId);

            modelBuilder.Entity<SeriesPurchase>()
                .HasOne(usp => usp.Series)
                .WithMany(s => s.SeriesPurchases)
                .HasForeignKey(usp => usp.SeriesId);

            // New entity relationships
            modelBuilder.Entity<UserSettings>()
                .HasOne(us => us.User)
                .WithOne(u => u.Settings)
                .HasForeignKey<UserSettings>(us => us.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Video)
                .WithMany()
                .HasForeignKey(f => f.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Series)
                .WithMany()
                .HasForeignKey(f => f.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Video)
                .WithMany()
                .HasForeignKey(ci => ci.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Series)
                .WithMany()
                .HasForeignKey(ci => ci.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ViewHistory>()
                .HasOne(vh => vh.User)
                .WithMany(u => u.ViewHistory)
                .HasForeignKey(vh => vh.UserId);

            modelBuilder.Entity<ViewHistory>()
                .HasOne(vh => vh.Video)
                .WithMany()
                .HasForeignKey(vh => vh.VideoId);

            // Indexes for performance
            modelBuilder.Entity<Favorite>()
                .HasIndex(f => new { f.UserId, f.VideoId, f.SeriesId })
                .IsUnique();

            modelBuilder.Entity<ViewHistory>()
                .HasIndex(vh => new { vh.UserId, vh.VideoId });

           // DataSeeder.SeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "NetFilmx"));
            }
        }



    }

    public class NetFilmxDbContextFactory : IDesignTimeDbContextFactory<NetFilmxDbContext>
    {
        public NetFilmxDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NetFilmxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "NetFilmx"));




            return new NetFilmxDbContext(optionsBuilder.Options);
        }
    }
}