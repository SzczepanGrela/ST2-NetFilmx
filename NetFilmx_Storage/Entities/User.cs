﻿using NetFilmx_Storage.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Users", Schema = "NetFilmx")]
    public class User : BaseEntity
    {
        internal User()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            VideoPurchases = new List<VideoPurchase>();
            SeriesPurchases = new List<SeriesPurchase>();
            Favorites = new List<Favorite>();
            ViewHistory = new List<ViewHistory>();
        }

        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            SetPassword(password);
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

    
        public virtual ICollection<Like> Likes { get; set; }


        public virtual ICollection<VideoPurchase> VideoPurchases { get; set; }


        public virtual ICollection<SeriesPurchase> SeriesPurchases { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<ViewHistory> ViewHistory { get; set; }

        public virtual UserSettings? Settings { get; set; }

        public virtual UserProfile? Profile { get; set; }

        public virtual Cart? Cart { get; set; }

        [NotMapped]
        public IEnumerable<Video> CommentedVideos => Comments.Select(c => c.Video);

        [NotMapped]
        public IEnumerable<Video> LikedVideos => Likes.Select(l => l.Video);

        [NotMapped]
        public IEnumerable<Video> FavoriteVideos => Favorites.Where(f => f.Video != null).Select(f => f.Video!);

        [NotMapped]
        public IEnumerable<Series> FavoriteSeries => Favorites.Where(f => f.Series != null).Select(f => f.Series!);

        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
