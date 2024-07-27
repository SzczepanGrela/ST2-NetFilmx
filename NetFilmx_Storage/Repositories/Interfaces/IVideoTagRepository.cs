using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoTagRepository
    {
        List<VideoTag> GetVideoTagsByVideoId(int id);

        VideoTag GetVideoTagByVideoIdTagId(int videoId, int tagId);
        void AddVideoTag(VideoTag videoTag);
        void DeleteVideoTag(int id);

        bool IsVideoTagExist(int video_Id, int tag_Id);
    }
}
