using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Service.Dtos.UserSettings;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.UserSettings
{
    public class GetUserSettingsByUserIdQueryHandler : IRequestHandler<GetUserSettingsByUserIdQuery<UserSettingsDetailsDto>, CResult<UserSettingsDetailsDto>>
    {
        private readonly IUserSettingsRepository _userSettingsRepository;

        public GetUserSettingsByUserIdQueryHandler(IUserSettingsRepository userSettingsRepository)
        {
            _userSettingsRepository = userSettingsRepository;
        }

        public async Task<CResult<UserSettingsDetailsDto>> Handle(GetUserSettingsByUserIdQuery<UserSettingsDetailsDto> request, CancellationToken cancellationToken)
        {
            try
            {
                var userSettings = await _userSettingsRepository.GetByUserIdAsync(request.UserId);
                
                if (userSettings == null)
                {
                    return CResult<UserSettingsDetailsDto>.Failure("User settings not found");
                }

                var dto = new UserSettingsDetailsDto(
                    userSettings.Id,
                    userSettings.UserId,
                    userSettings.EmailNotifications,
                    userSettings.AutoplayEnabled,
                    userSettings.Theme,
                    userSettings.Language,
                    userSettings.HighQualityDefault,
                    userSettings.ShowAdultContent,
                    userSettings.CreatedAt,
                    userSettings.UpdatedAt
                );

                return CResult<UserSettingsDetailsDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return CResult<UserSettingsDetailsDto>.Failure($"Failed to get user settings: {ex.Message}");
            }
        }
    }
}