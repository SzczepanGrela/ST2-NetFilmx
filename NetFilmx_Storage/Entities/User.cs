using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetFilmx_Storage.Common;

namespace NetFilmx_Storage.Entities
{
    [Table("Users", Schema = "NetFilmx_dodaneZakupy")]
    public class User : BaseEntity
    {
        internal User()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            VideoPurchases = new List<VideoPurchase>();
            SeriesPurchases = new List<SeriesPurchase>();
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
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(Comment.User))]
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty(nameof(Like.User))]
        public virtual ICollection<Like> Likes { get; set; }

        [InverseProperty(nameof(VideoPurchase.User))]
        public virtual ICollection<VideoPurchase> VideoPurchases { get; set; }

        [InverseProperty(nameof(SeriesPurchase.User))]
        public virtual ICollection<SeriesPurchase> SeriesPurchases { get; set; }

        [NotMapped]
        public IEnumerable<Video> CommentedVideos => Comments.Select(c => c.Video);

        [NotMapped]
        public IEnumerable<Video> LikedVideos => Likes.Select(l => l.Video);

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
