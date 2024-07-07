using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ILikeRepository
    {
        List<Like> GetLikesByVideoId(long videoId);
        Like GetLikeById(long id);
        void AddLike(Like like);
        void RemoveLike(long id);
    }
}
