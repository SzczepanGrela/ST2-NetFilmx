namespace NetFilmx_Service.Dtos.UserSettings
{
    public class UserSettingsDetailsDto : IUserSettingsDto
    {
        public UserSettingsDetailsDto(int id, int userId, bool emailNotifications, bool autoplayEnabled, 
            string theme, string language, bool highQualityDefault, bool showAdultContent, 
            DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            EmailNotifications = emailNotifications;
            AutoplayEnabled = autoplayEnabled;
            Theme = theme;
            Language = language;
            HighQualityDefault = highQualityDefault;
            ShowAdultContent = showAdultContent;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; }
        public int UserId { get; }
        public bool EmailNotifications { get; }
        public bool AutoplayEnabled { get; }
        public string Theme { get; }
        public string Language { get; }
        public bool HighQualityDefault { get; }
        public bool ShowAdultContent { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }
}