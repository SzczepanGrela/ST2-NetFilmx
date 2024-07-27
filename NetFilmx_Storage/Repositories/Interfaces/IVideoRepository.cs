using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetVideos();
        Video GetVideoById(int id);
        void AddVideo(Video video);
        void EditVideo(Video video);
        void DeleteVideo(int id);

        bool IsVideoExist(int id);
        
    }
}
