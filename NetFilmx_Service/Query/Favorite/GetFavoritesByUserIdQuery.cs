using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Favorite
{
    public sealed class GetFavoritesByUserIdQuery<T> : IRequest<CResult<IEnumerable<T>>>
    {
        public GetFavoritesByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}