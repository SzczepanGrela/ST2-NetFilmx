using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.UserSettings
{
    public sealed class EditUserSettingsCommand : IRequest<CResult>
    {
        public EditUserSettingsCommand(int userId, bool emailNotifications, bool autoplay, 
            string theme, string language)
        {
            UserId = userId;
            EmailNotifications = emailNotifications;
            Autoplay = autoplay;
            Theme = theme;
            Language = language;
        }

        public int UserId { get; }
        public bool EmailNotifications { get; }
        public bool Autoplay { get; }
        public string Theme { get; }
        public string Language { get; }
    }
}