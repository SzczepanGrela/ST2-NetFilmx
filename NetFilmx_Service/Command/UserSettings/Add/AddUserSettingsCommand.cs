using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.UserSettings
{
    public sealed class AddUserSettingsCommand : IRequest<CResult>
    {
        public AddUserSettingsCommand(int userId, bool emailNotifications = true, bool autoplay = true, 
            string theme = "light", string language = "en")
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