﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Series> Series { get; set; }

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

            DataSeeder.SeedData(modelBuilder);
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