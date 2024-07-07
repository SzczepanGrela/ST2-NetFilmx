using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage
{
    internal class NetFilmxDbContext : DbContext
    {
        private IConfiguration _configuration { get; }

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


        public NetFilmxDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = ACER_NITRO_5; Database = NetFilmxDb; Trusted_Connection = True; TrustServerCertificate = True;",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "NetFilmx"));
            }
        }
            



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
