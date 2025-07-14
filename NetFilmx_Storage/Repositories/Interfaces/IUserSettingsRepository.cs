using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface IUserSettingsRepository
    {
        Task<UserSettings> AddAsync(UserSettings userSettings);
        Task<UserSettings?> GetByIdAsync(int id);
        Task<UserSettings?> GetByUserIdAsync(int userId);
        Task UpdateAsync(UserSettings userSettings);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserSettings>> GetAllAsync();
    }
}