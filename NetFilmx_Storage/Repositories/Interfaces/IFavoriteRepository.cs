using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface IFavoriteRepository
    {
        Task<Favorite> AddAsync(Favorite favorite);
        Task<Favorite?> GetByIdAsync(int id);
        Task<IEnumerable<Favorite>> GetByUserIdAsync(int userId);
        Task<Favorite?> GetByUserAndVideoAsync(int userId, int videoId);
        Task<Favorite?> GetByUserAndSeriesAsync(int userId, int seriesId);
        Task DeleteAsync(int id);
        Task<IEnumerable<Favorite>> GetAllAsync();
    }
}