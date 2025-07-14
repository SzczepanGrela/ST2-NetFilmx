using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Context;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class UserSettingsRepository : IUserSettingsRepository
    {
        private readonly NetFilmxDbContext _context;

        public UserSettingsRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<UserSettings> AddAsync(UserSettings userSettings)
        {
            _context.UserSettings.Add(userSettings);
            await _context.SaveChangesAsync();
            return userSettings;
        }

        public async Task<UserSettings?> GetByIdAsync(int id)
        {
            return await _context.UserSettings
                .Include(us => us.User)
                .FirstOrDefaultAsync(us => us.Id == id);
        }

        public async Task<UserSettings?> GetByUserIdAsync(int userId)
        {
            return await _context.UserSettings
                .Include(us => us.User)
                .FirstOrDefaultAsync(us => us.UserId == userId);
        }

        public async Task UpdateAsync(UserSettings userSettings)
        {
            _context.UserSettings.Update(userSettings);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userSettings = await _context.UserSettings.FindAsync(id);
            if (userSettings != null)
            {
                _context.UserSettings.Remove(userSettings);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserSettings>> GetAllAsync()
        {
            return await _context.UserSettings
                .Include(us => us.User)
                .ToListAsync();
        }
    }
}