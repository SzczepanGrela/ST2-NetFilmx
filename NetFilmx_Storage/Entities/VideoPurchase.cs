using NetFilmx_Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("VideoPurchases", Schema = "NetFilmx")]
    public class VideoPurchase : BaseEntity
    {
        public VideoPurchase() { }

        public VideoPurchase(int userId, int videoId)
        {
            UserId = userId;
            VideoId = videoId;
            PurchaseDate = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.VideoPurchases))]
        public virtual User User { get; set; }

        [Required]
        public int VideoId { get; set; }

        [ForeignKey(nameof(VideoId))]
        [InverseProperty(nameof(Video.VideoPurchases))]
        public virtual Video Video { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}
