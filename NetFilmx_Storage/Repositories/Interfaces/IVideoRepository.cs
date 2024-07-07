using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetVideos();
        Video GetVideoById(long id);
        void AddVideo(Video video);
        void EditVideo(Video video);
        void RemoveVideo(long id);
        bool IsVideoExist(long videoId);
    }
}
