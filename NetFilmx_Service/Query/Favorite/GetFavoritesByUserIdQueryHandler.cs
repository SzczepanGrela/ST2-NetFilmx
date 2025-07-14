using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Service.Dtos.Favorite;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Favorite
{
    public class GetFavoritesByUserIdQueryHandler : IRequestHandler<GetFavoritesByUserIdQuery<FavoriteListDto>, CResult<IEnumerable<FavoriteListDto>>>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public GetFavoritesByUserIdQueryHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<CResult<IEnumerable<FavoriteListDto>>> Handle(GetFavoritesByUserIdQuery<FavoriteListDto> request, CancellationToken cancellationToken)
        {
            try
            {
                var favorites = await _favoriteRepository.GetByUserIdAsync(request.UserId);
                
                var favoriteDtos = favorites.Select(f => new FavoriteListDto(
                    f.Id,
                    f.UserId,
                    f.VideoId,
                    f.SeriesId,
                    f.CreatedAt,
                    f.Video?.Title,
                    f.Series?.Name,
                    f.Video?.ThumbnailUrl,
                    f.Video?.Price ?? f.Series?.Price ?? 0
                )).ToList();

                return CResult<IEnumerable<FavoriteListDto>>.Success(favoriteDtos);
            }
            catch (Exception ex)
            {
                return CResult<IEnumerable<FavoriteListDto>>.Failure($"Failed to get user favorites: {ex.Message}");
            }
        }
    }
}