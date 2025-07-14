using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Favorite
{
    public sealed class DeleteFavoriteCommand : IRequest<CResult>
    {
        public DeleteFavoriteCommand(int favoriteId)
        {
            FavoriteId = favoriteId;
        }

        public int FavoriteId { get; }
    }
}