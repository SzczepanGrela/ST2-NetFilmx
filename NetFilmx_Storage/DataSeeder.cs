using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Entities;
using System;

namespace NetFilmx_Storage
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var categories = new[]
            {
                new Category { Id = 1, Name = "Zwierzęta", Description = "Podziwiaj niesamowity świat natury" },
                new Category { Id = 2, Name = "Rozwój", Description = "Filmy edukacyjne" },
                new Category { Id = 3, Name = "Rozrywka", Description = "Zabawne i edukacyjne filmy" },
            };

            var tags = new[]
            {
                new Tag { Id = 1, Name = "Zwierzęta" },
                new Tag { Id = 2, Name = "Koty" },
                new Tag { Id = 3, Name = "Rozrywka" },
                new Tag { Id = 4, Name = "Zabawne" },
                new Tag { Id = 5, Name = "Edukacyjne" },
                new Tag { Id = 6, Name = "Rozwój" },
                new Tag { Id = 7, Name = "Programowanie" },
                new Tag { Id = 8, Name = "Lockpicking" },
            };

            var series = new[]
            {
                new Series { Id = 1, Name = "Pakiet wszystkich startowych filmów", Price = 149.99m, Description = "Kup zestaw oryginalnych 9 filmów dostępnych na platformie", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Series { Id = 2, Name = "Pakiet świata zwierząt", Price = 49.99m, Description = "Zestaw zawierający 6 filmów poświęconych zwierzętom", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Series { Id = 3, Name = "Pakiet rozwoju", Price = 59.99m, Description = "Zestaw zawierający 3 filmy edukacyjne", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Series { Id = 4, Name = "Pakiet promocyjny", Price = 19.99m, Description = "Zestaw zawierający 3 filmy promocyjne, po jednym z każdej kategorii", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            var videos = new[]
            {
                new Video
                {
                    Id = 1,
                    Title = "Amazing Scene of Wild Animals In 4K",
                    Description = "Discover amazing wildlife and relax! ...",
                    Price = 9.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=5kozt0uDa4c",
                    ThumbnailUrl = "https://i.ytimg.com/vi/5kozt0uDa4c/hqdefault.jpg",
                    CreatedAt = new DateTime(2021, 8, 15),
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 2,
                    Title = "Ultimate Wild Animals Collection in 8K ULTRA HD",
                    Description = "Ultimate Wild Animals Collection in 8K ULTRA HD ...",
                    Price = 4.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=Zv11L-ZfrSg",
                    ThumbnailUrl = "https://i.ytimg.com/vi/Zv11L-ZfrSg/hqdefault.jpg",
                    CreatedAt = new DateTime(2021, 1, 24),
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 3,
                    Title = "Baby Animals 4K - Amazing World Of Young Animals",
                    Description = "Sit back and relax while enjoying this scenic film ...",
                    Price = 6.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=oRDRfikj2z8",
                    ThumbnailUrl = "https://i.ytimg.com/vi/oRDRfikj2z8/hqdefault.jpg",
                    CreatedAt = new DateTime(2022, 9, 16),
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 4,
                    Title = "20 Minutes of Adorable Kittens",
                    Description = "Cute, cuddly, and utterly chaotic! ...",
                    Price = 14.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=y0sF5xhGreA",
                    ThumbnailUrl = "https://i.ytimg.com/vi/y0sF5xhGreA/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 5,
                    Title = "Baby Cats - Cute and Funny Cat Videos Compilation",
                    Description = "Watching funny baby cats is the hardest try not to laugh challenge.",
                    Price = 19.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=cytJLvf-eVs",
                    ThumbnailUrl = "https://i.ytimg.com/vi/cytJLvf-eVs/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 6,
                    Title = "Cute and Funny Cat Videos to Keep You Smiling!",
                    Description = "Hoomans! Rufus here! ...",
                    Price = 12.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=tpiyEe_CqB4",
                    ThumbnailUrl = "https://i.ytimg.com/vi/tpiyEe_CqB4/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 7,
                    Title = "Entity Framework Core Migration",
                    Description = "Asp.net core MVC 6.0 tutorial for beginners.",
                    Price = 14.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=fFY9nxfILJQ",
                    ThumbnailUrl = "https://i.ytimg.com/vi/fFY9nxfILJQ/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 8,
                    Title = "The Most Significant Security Flaw in North America",
                    Description = "This video explores a significant security flaw discussed by LockPickingLawyer.",
                    Price = 19.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=U5-qy2tbDG8",
                    ThumbnailUrl = "https://i.ytimg.com/vi/U5-qy2tbDG8/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Video
                {
                    Id = 9,
                    Title = "The Unity Tutorial For Complete Beginners",
                    Description = "Unity is an amazingly powerful game engine - but it can be hard to learn ...",
                    Price = 12.99m,
                    VideoUrl = "https://www.youtube.com/watch?v=XtQMytORBmM",
                    ThumbnailUrl = "https://i.ytimg.com/vi/XtQMytORBmM/hqdefault.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            var users = new[]
            {
                new User { Id = 1, Username = "User1", Email = "user1@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("User1"), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = 2, Username = "User2", Email = "user2@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("User2"), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new User { Id = 3, Username = "User3", Email = "user3@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("User3"), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            };

            var comments = new[]
            {
                new Comment { Id = 1, VideoId = 1, UserId = 1, Content = "This is a comment for the first video.", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Comment { Id = 2, VideoId = 2, UserId = 2, Content = "This is a comment for the second video.", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            var likes = new[]
            {
                new Like { Id = 1, VideoId = 1, UserId = 1, CreatedAt = DateTime.Now },
                new Like { Id = 2, VideoId = 2, UserId = 2, CreatedAt = DateTime.Now }
            };

            var VideoPurchases = new[]
            {
            new VideoPurchase { Id = 1, UserId = 2, VideoId = 4, PurchaseDate = DateTime.Now },
            new VideoPurchase { Id = 2, UserId = 3, VideoId = 5, PurchaseDate = DateTime.Now },
            };

            var SeriesPurchases = new[]
            {
            new SeriesPurchase { Id = 1, UserId = 1, SeriesId = 1, PurchaseDate = DateTime.Now },
            new SeriesPurchase { Id = 2, UserId = 1, SeriesId = 2, PurchaseDate = DateTime.Now },
            new SeriesPurchase { Id = 3, UserId = 1, SeriesId = 3, PurchaseDate = DateTime.Now },
            new SeriesPurchase { Id = 4, UserId = 1, SeriesId = 4, PurchaseDate = DateTime.Now },
            new SeriesPurchase { Id = 5, UserId = 2, SeriesId = 2, PurchaseDate = DateTime.Now }
            };




            var videoTags = new[]
            {
                new { VideoId = 1, TagId = 1 },
                new { VideoId = 1, TagId = 5 },
                new { VideoId = 2, TagId = 1 },
                new { VideoId = 2, TagId = 5 },
                new { VideoId = 3, TagId = 1 },
                new { VideoId = 3, TagId = 5 },
                new { VideoId = 4, TagId = 2 },
                new { VideoId = 4, TagId = 4 },
                new { VideoId = 5, TagId = 2 },
                new { VideoId = 5, TagId = 4 },
                new { VideoId = 6, TagId = 2 },
                new { VideoId = 6, TagId = 4 },
                new { VideoId = 6, TagId = 1 },
                new { VideoId = 5, TagId = 1 },
                new { VideoId = 4, TagId = 1 },
                new { VideoId = 7, TagId = 7 },
                new { VideoId = 8, TagId = 8 },
                new { VideoId = 9, TagId = 6 },
                new { VideoId = 9, TagId = 7 },
                new { VideoId = 7, TagId = 6 }
            };

            var videoCategories = new[]
            {
                new { VideoId = 1, CategoryId = 1 },
                new { VideoId = 1, CategoryId = 3 },
                new { VideoId = 2, CategoryId = 1 },
                new { VideoId = 2, CategoryId = 3 },
                new { VideoId = 3, CategoryId = 1 },
                new { VideoId = 3, CategoryId = 3 },
                new { VideoId = 4, CategoryId = 1 },
                new { VideoId = 4, CategoryId = 3 },
                new { VideoId = 5, CategoryId = 1 },
                new { VideoId = 5, CategoryId = 3 },
                new { VideoId = 6, CategoryId = 1 },
                new { VideoId = 6, CategoryId = 3 },
                new { VideoId = 7, CategoryId = 2 },
                new { VideoId = 8, CategoryId = 2 },
                new { VideoId = 8, CategoryId = 3 },
                new { VideoId = 9, CategoryId = 2 }
            };

            var videoSeries = new[]
            {
                new { VideoId = 1, SeriesId = 1 },
                new { VideoId = 2, SeriesId = 1 },
                new { VideoId = 3, SeriesId = 1 },
                new { VideoId = 4, SeriesId = 1 },
                new { VideoId = 5, SeriesId = 1 },
                new { VideoId = 6, SeriesId = 1 },
                new { VideoId = 1, SeriesId = 2 },
                new { VideoId = 2, SeriesId = 2 },
                new { VideoId = 3, SeriesId = 2 },
                new { VideoId = 4, SeriesId = 2 },
                new { VideoId = 5, SeriesId = 2 },
                new { VideoId = 6, SeriesId = 2 },
                new { VideoId = 7, SeriesId = 3 },
                new { VideoId = 8, SeriesId = 3 },
                new { VideoId = 9, SeriesId = 3 },
                new { VideoId = 7, SeriesId = 4 },
                new { VideoId = 8, SeriesId = 4 },
                new { VideoId = 9, SeriesId = 4 }
            };

            modelBuilder.Entity<Video>().HasData(videos);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Tag>().HasData(tags);
            modelBuilder.Entity<Series>().HasData(series);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Like>().HasData(likes);
            modelBuilder.Entity<VideoPurchase>().HasData(VideoPurchases);
            modelBuilder.Entity<SeriesPurchase>().HasData(SeriesPurchases);
            modelBuilder.Entity("VideoTag").HasData(videoTags);
            modelBuilder.Entity("VideoCategory").HasData(videoCategories);
            modelBuilder.Entity("VideoSeries").HasData(videoSeries);
        }
    }
}