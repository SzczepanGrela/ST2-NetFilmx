using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Favorites", Schema = "NetFilmx")]
    public class Favorite : BaseEntity
    {
        internal Favorite()
        {
        }

        public Favorite(int userId, int? videoId = null, int? seriesId = null)
        {
            if (videoId == null && seriesId == null)
                throw new ArgumentException("Either VideoId or SeriesId must be provided");
            
            if (videoId != null && seriesId != null)
                throw new ArgumentException("Only VideoId or SeriesId can be provided, not both");

            UserId = userId;
            VideoId = videoId;
            SeriesId = seriesId;
            CreatedAt = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        public int? VideoId { get; set; }

        public int? SeriesId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [ForeignKey("VideoId")]
        public virtual Video? Video { get; set; }

        [ForeignKey("SeriesId")]
        public virtual Series? Series { get; set; }
    }
}