using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> GetAllSeries();
        List<Series> GetSeriesByVideoId(int videoId);
        List<Series> GetBoughtSeriesByUserId(int userId);
       
        Series GetSeriesById(int seriesId);
        Series GetSeriesByName(string seriesName);
       
        void AddSeries(Series series);
        void UpdateSeries(Series series);
        void DeleteSeries(int seriesId);

        bool IsSeriesExist(string seriesName);
        bool IsSeriesExist(int seriesId);

        
    }
}
