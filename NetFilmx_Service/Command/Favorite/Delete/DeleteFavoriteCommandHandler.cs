using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Favorite
{
    public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, CResult>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public DeleteFavoriteCommandHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<CResult> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var favorite = await _favoriteRepository.GetByIdAsync(request.FavoriteId);
                if (favorite == null)
                {
                    return CResult.Failure("Favorite not found");
                }

                await _favoriteRepository.DeleteAsync(request.FavoriteId);
                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to delete favorite: {ex.Message}");
            }
        }
    }
}