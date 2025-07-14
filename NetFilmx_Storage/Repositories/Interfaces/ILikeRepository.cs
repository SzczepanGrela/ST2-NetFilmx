using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface ILikeRepository
    {
        Task<int> GetLikesCountByVideoIdAsync(int videoId);
        Task<Like> AddAsync(Like like);
        Task AddLikeAsync(Like like);
        Task DeleteAsync(int likeId);
        Task DeleteLikeAsync(int likeId);
        Task<bool> IsLikeExistAsync(int video_Id, int user_Id);
        Task<Like?> GetByUserAndVideoAsync(int userId, int videoId);
    }
}
