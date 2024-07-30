using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ILikeRepository
    {
        int GetLikesCountByVideoId(int videoId);
        void AddLike(Like like);
        void DeleteLike(int likeId);
        bool IsLikeExist(int video_Id, int user_Id);
    }
}
