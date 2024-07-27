using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoSeriesRepository
    {
        List<VideoSeries> GetVideoSeriesBySeriesId(int series_Id);
        void AddVideoSeries(VideoSeries videoSeries);
        void DeleteVideoSeries(int id);

        bool IsVideoSeriesExist(int video_Id, int series_Id);
    }
}
