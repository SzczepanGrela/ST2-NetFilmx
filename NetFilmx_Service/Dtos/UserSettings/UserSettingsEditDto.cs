using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Service.Dtos.UserSettings
{
    public class UserSettingsEditDto : IUserSettingsDto
    {
        public UserSettingsEditDto() { }

        public UserSettingsEditDto(int id, int userId, bool emailNotifications, bool autoplayEnabled, 
            string theme, string language, bool highQualityDefault, bool showAdultContent)
        {
            Id = id;
            UserId = userId;
            EmailNotifications = emailNotifications;
            AutoplayEnabled = autoplayEnabled;
            Theme = theme;
            Language = language;
            HighQualityDefault = highQualityDefault;
            ShowAdultContent = showAdultContent;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public bool EmailNotifications { get; set; }

        [Required]
        public bool AutoplayEnabled { get; set; }

        [Required]
        [MaxLength(20)]
        public string Theme { get; set; } = "dark";

        [Required]
        [MaxLength(10)]
        public string Language { get; set; } = "en";

        [Required]
        public bool HighQualityDefault { get; set; }

        [Required]
        public bool ShowAdultContent { get; set; }
    }
}