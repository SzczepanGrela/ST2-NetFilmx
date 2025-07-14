using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("UserProfiles", Schema = "NetFilmx")]
    public class UserProfile : BaseEntity
    {
        internal UserProfile()
        {
        }

        public UserProfile(int userId)
        {
            UserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string? ProfileImageUrl { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(100)]
        public string? DisplayName { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginCount { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}