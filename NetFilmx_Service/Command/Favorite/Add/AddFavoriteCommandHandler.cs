using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Favorite
{
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, CResult>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public AddFavoriteCommandHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<CResult> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.VideoId == null && request.SeriesId == null)
                {
                    return CResult.Failure("Either VideoId or SeriesId must be provided");
                }

                if (request.VideoId != null && request.SeriesId != null)
                {
                    return CResult.Failure("Cannot add both Video and Series as favorite at the same time");
                }

                var favorite = new NetFilmx_Storage.Entities.Favorite(request.UserId, request.VideoId, request.SeriesId);

                var result = await _favoriteRepository.AddAsync(favorite);
                return CResult.Success(result.Id);
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to add favorite: {ex.Message}");
            }
        }
    }
}