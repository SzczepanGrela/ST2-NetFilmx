using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> GetSeries();
        Series GetSeriesById(int id);
        void AddSeries(Series series);
        void EditSeries(Series series);
        void DeleteSeries(int id);

        bool IsSeriesExist(string Name);

        
    }
}
