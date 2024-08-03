using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface ILikeRepository
    {
        Task<int> GetLikesCountByVideoIdAsync(int videoId);
        Task AddLikeAsync(Like like);
        Task DeleteLikeAsync(int likeId);
        Task<bool> IsLikeExistAsync(int video_Id, int user_Id);
    }
}
