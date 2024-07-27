using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using NetFilmx_Storage.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace NetFilmx_Storage.Repositories
{
    public interface IVideoCategoryRepository
    {
        List<VideoCategory> GetVideoCategoriesByVideoId(int videoId);
        void AddVideoCategory(VideoCategory videoCategory);
        void DeleteVideoCategory(int id);
        bool IsVideoCategoryExist(int video_Id, int category_Id);
    }
}
