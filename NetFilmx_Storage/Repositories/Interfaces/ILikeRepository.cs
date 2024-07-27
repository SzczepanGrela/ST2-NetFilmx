using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ILikeRepository
    {
        List<Like> GetLikesByVideoId(int videoId);
        Like GetLikeById(int id);
        void AddLike(Like like);
        void DeleteLike(int id);

        bool IsLikeExist(int video_Id, int user_Id);
    }
}
