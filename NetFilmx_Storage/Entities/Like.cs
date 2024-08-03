using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Likes", Schema = "NetFilmx")]
    public class Like : BaseEntity
    {
        internal Like() 
        { 
            User = new User();
            Video = new Video();
        }

        public Like(int videoId, int userId) : this()
        {
            VideoId = videoId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }


        [Required]
        public int VideoId { get; set; }


        [ForeignKey(nameof(VideoId))]
        [InverseProperty(nameof(Video.Likes))]
        public virtual Video Video { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.Likes))]
        public virtual User User { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
