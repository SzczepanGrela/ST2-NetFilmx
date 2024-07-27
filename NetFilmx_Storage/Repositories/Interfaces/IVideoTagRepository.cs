using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoTagRepository
    {
        List<VideoTag> GetVideoTagsByVideoId(int video_Id);
        void AddVideoTag(VideoTag videoTag);
        void RemoveVideoTag(int id);

        bool IsVideoTagExist(int video_Id, int tag_Id);
    }
}
