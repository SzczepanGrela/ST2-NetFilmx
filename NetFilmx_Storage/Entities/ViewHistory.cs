using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("ViewHistory", Schema = "NetFilmx")]
    public class ViewHistory : BaseEntity
    {
        internal ViewHistory()
        {
        }

        public ViewHistory(int userId, int videoId, int watchTimeSeconds = 0)
        {
            UserId = userId;
            VideoId = videoId;
            WatchTimeSeconds = watchTimeSeconds;
            ViewedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        public int WatchTimeSeconds { get; set; } = 0; // How long user watched

        public int? VideoDurationSeconds { get; set; } // Total video duration

        [Required]
        public DateTime ViewedAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Calculated properties
        [NotMapped]
        public bool IsCompleted => VideoDurationSeconds.HasValue && 
                                   WatchTimeSeconds >= VideoDurationSeconds * 0.9; // 90% watched = completed

        [NotMapped]
        public decimal ProgressPercentage => VideoDurationSeconds.HasValue && VideoDurationSeconds > 0 
                                            ? Math.Min(100, (decimal)WatchTimeSeconds / VideoDurationSeconds.Value * 100)
                                            : 0;

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; } = null!;
    }
}