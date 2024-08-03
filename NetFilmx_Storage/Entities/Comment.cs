using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Comments", Schema = "NetFilmx")]
    public class Comment : BaseEntity
    {
        internal Comment() { }

        public Comment(int videoId, int userId, string content)
        {
            VideoId = videoId;
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey(nameof(VideoId))]
        [InverseProperty(nameof(Video.Comments))]
        public virtual Video Video { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.Comments))]
        public virtual User User { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
