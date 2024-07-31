using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesRepository
    {
        Task<List<Series>> GetAllSeriesAsync();
        Task<List<Series>> GetSeriesByVideoIdAsync(int videoId);
        Task<List<Series>> GetBoughtSeriesByUserIdAsync(int userId);

        Task<Series> GetSeriesByIdAsync(int seriesId);
        Task<Series> GetSeriesByNameAsync(string seriesName);

        Task AddSeriesAsync(Series series);
        Task UpdateSeriesAsync(Series series);
        Task DeleteSeriesAsync(int seriesId);

        Task<bool> IsSeriesExistAsync(string seriesName);
        Task<bool> IsSeriesExistAsync(int seriesId);

        Task<int> GetSeriesCountByIdAsync(int seriesId);
        Task<int> GetSeriesCountByNameAsync(string seriesName);


    }
}
