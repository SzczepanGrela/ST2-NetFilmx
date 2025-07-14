using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.ViewHistory;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.ViewHistory.GetContinueWatching
{
    public class GetContinueWatchingQueryHandler : IRequestHandler<GetContinueWatchingQuery<ViewHistoryDetailsDto>, CResult<List<ViewHistoryDetailsDto>>>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;
        private readonly IMapper _mapper;

        public GetContinueWatchingQueryHandler(IViewHistoryRepository viewHistoryRepository, IMapper mapper)
        {
            _viewHistoryRepository = viewHistoryRepository;
            _mapper = mapper;
        }

        public async Task<CResult<List<ViewHistoryDetailsDto>>> Handle(GetContinueWatchingQuery<ViewHistoryDetailsDto> request, CancellationToken cancellationToken)
        {
            try
            {
                var continueWatching = await _viewHistoryRepository.GetContinueWatchingAsync(request.UserId);
                
                var continueWatchingDtos = continueWatching.Select(vh => new ViewHistoryDetailsDto
                {
                    Id = vh.Id,
                    UserId = vh.UserId,
                    VideoId = vh.VideoId,
                    ProgressSeconds = vh.WatchTimeSeconds,
                    DurationSeconds = vh.VideoDurationSeconds ?? 0,
                    IsCompleted = vh.IsCompleted,
                    LastWatchedAt = vh.ViewedAt,
                    CreatedAt = vh.CreatedAt,
                    VideoTitle = vh.Video?.Title ?? "Unknown Video",
                    VideoDescription = vh.Video?.Description ?? "",
                    VideoPrice = vh.Video?.Price ?? 0,
                    VideoThumbnailUrl = vh.Video?.ThumbnailUrl,
                    VideoUrl = vh.Video?.VideoUrl
                }).ToList();

                return CResult<List<ViewHistoryDetailsDto>>.Success(continueWatchingDtos);
            }
            catch (Exception ex)
            {
                return CResult<List<ViewHistoryDetailsDto>>.Failure($"Error getting continue watching: {ex.Message}");
            }
        }
    }
}