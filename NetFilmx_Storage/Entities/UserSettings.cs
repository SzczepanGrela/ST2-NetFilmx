using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("UserSettings", Schema = "NetFilmx")]
    public class UserSettings : BaseEntity
    {
        internal UserSettings()
        {
        }

        public UserSettings(int userId)
        {
            UserId = userId;
            EmailNotifications = true;
            AutoplayEnabled = true;
            Theme = "dark";
            Language = "en";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool EmailNotifications { get; set; }

        [Required] 
        public bool AutoplayEnabled { get; set; }

        [Required]
        [MaxLength(20)]
        public string Theme { get; set; } = "dark"; // dark, light

        [Required]
        [MaxLength(10)]
        public string Language { get; set; } = "en"; // en, pl

        public bool HighQualityDefault { get; set; } = true;

        public bool ShowAdultContent { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}