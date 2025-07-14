using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.UserSettings
{
    public class EditUserSettingsCommandHandler : IRequestHandler<EditUserSettingsCommand, CResult>
    {
        private readonly IUserSettingsRepository _userSettingsRepository;

        public EditUserSettingsCommandHandler(IUserSettingsRepository userSettingsRepository)
        {
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<CResult> Handle(EditUserSettingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSettings = await _userSettingsRepository.GetByUserIdAsync(request.UserId);
                if (userSettings == null)
                {
                    return CResult.Failure("User settings not found");
                }

                userSettings.EmailNotifications = request.EmailNotifications;
                userSettings.AutoplayEnabled = request.Autoplay;
                userSettings.Theme = request.Theme;
                userSettings.Language = request.Language;
                userSettings.UpdatedAt = DateTime.Now;

                await _userSettingsRepository.UpdateAsync(userSettings);
                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to update user settings: {ex.Message}");
            }
        }
    }
}