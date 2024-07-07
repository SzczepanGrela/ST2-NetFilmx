using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesRepository
    {
        List<Series> GetSeries();
        Series GetSeriesById(long id);
        void AddSeries(Series series);
        void EditSeries(Series series);
        void RemoveSeries(long id);
    }
}
