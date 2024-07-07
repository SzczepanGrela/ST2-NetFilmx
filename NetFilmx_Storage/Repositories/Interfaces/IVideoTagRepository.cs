using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoTagRepository
    {
        List<VideoTag> GetVideoTagsByVideoId(long videoId);
        void AddVideoTag(VideoTag videoTag);
        void RemoveVideoTag(long id);
    }
}
