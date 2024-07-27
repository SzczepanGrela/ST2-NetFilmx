using NetFilmx_Storage.Entities;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace NetFilmx_Storage.Repositories
{
    public interface IVideoCategoryRepository
    {
        List<VideoCategory> GetVideoCategoriesByVideoId(int videoId);

        VideoCategory GetVideoCategoryByVideoIdCategoryId(int videoId, int categoryId);
        void AddVideoCategory(VideoCategory videoCategory);
        void DeleteVideoCategory(int id);
        bool IsVideoCategoryExist(int video_Id, int category_Id);
    }
}
