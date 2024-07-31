using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideos();
        List<Video> GetVideosByCategoryId(int categoryId);
        List<Video> GetVideosBySeriesId(int seriesId);
        List<Video> GetVideosByTagId(int tagId);
        List<Video> GetVideosByUserId(int userId);

        
        List<Video>GetVideosByExcludedCategoryId(int categoryId);
        List<Video>GetVideosByExcludedSeriesId(int seriesId);
        List<Video>GetVideosByExcludedTagId(int tagId);

        Video GetVideoById(int videoId);
        Video GetVideoByVideoPurchaseId (int videoPurchaseId);
        Video GetVideoByCommentId (int commentId);
        Video GetVideoByLikeId (int likeId);

        void AddVideoToTag(int tagId, int videoId);
        void RemoveVideoFromTag(int tagId, int videoId);
        void AddVideoToSeries(int seriesId, int videoId);
        void RemoveVideoFromSeries(int seriesId, int videoId);
        void AddVideoToCategory(int categoryId, int videoId);
        void RemoveVideoFromCategory(int categoryId, int videoId);

        
        void AddVideo(Video video);
        void UpdateVideo(Video video);
        void DeleteVideo(int videoId);

        bool IsVideoExistInTag(int tagId, int videoId);
        bool IsVideoExistInSeries(int seriesId, int videoId);
        bool IsVideoExistInCategory(int categoryId, int videoId);
        bool IsVideoExist(int videoId);
        
    }
}
