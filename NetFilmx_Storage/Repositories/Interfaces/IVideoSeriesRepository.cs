using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoSeriesRepository
    {
        List<VideoSeries> GetVideoSeriesBySeriesId(long seriesId);
        void AddVideoSeries(VideoSeries videoSeries);
        void RemoveVideoSeries(long id);
    }
}
