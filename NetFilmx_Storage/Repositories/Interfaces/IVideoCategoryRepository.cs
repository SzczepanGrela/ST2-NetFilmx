using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using NetFilmx_Storage.Entities;
namespace NetFilmx_Storage.Repositories
{
    public interface IVideoCategoryRepository
    {
        List<VideoCategory> GetVideoCategoriesByVideoId(long videoId);
        void AddVideoCategory(VideoCategory videoCategory);
        void RemoveVideoCategory(long id);
    }
}
