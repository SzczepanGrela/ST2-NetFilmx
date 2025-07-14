using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.UserSettings
{
    public class AddUserSettingsCommandHandler : IRequestHandler<AddUserSettingsCommand, CResult>
    {
        private readonly IUserSettingsRepository _userSettingsRepository;

        public AddUserSettingsCommandHandler(IUserSettingsRepository userSettingsRepository)
        {
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<CResult> Handle(AddUserSettingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userSettings = new NetFilmx_Storage.Entities.UserSettings(request.UserId)
                {
                    EmailNotifications = request.EmailNotifications,
                    AutoplayEnabled = request.Autoplay,
                    Theme = request.Theme,
                    Language = request.Language
                };

                var result = await _userSettingsRepository.AddAsync(userSettings);
                return CResult.Success(result.Id);
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to create user settings: {ex.Message}");
            }
        }
    }
}