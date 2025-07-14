using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.ViewHistory;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.ViewHistory.GetByUserId
{
    public class GetViewHistoryByUserIdQueryHandler : IRequestHandler<GetViewHistoryByUserIdQuery<ViewHistoryDetailsDto>, CResult<List<ViewHistoryDetailsDto>>>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;
        private readonly IMapper _mapper;

        public GetViewHistoryByUserIdQueryHandler(IViewHistoryRepository viewHistoryRepository, IMapper mapper)
        {
            _viewHistoryRepository = viewHistoryRepository;
            _mapper = mapper;
        }

        public async Task<CResult<List<ViewHistoryDetailsDto>>> Handle(GetViewHistoryByUserIdQuery<ViewHistoryDetailsDto> request, CancellationToken cancellationToken)
        {
            try
            {
                var viewHistories = await _viewHistoryRepository.GetByUserIdAsync(request.UserId);
                
                var viewHistoryDtos = viewHistories.Select(vh => new ViewHistoryDetailsDto
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

                return CResult<List<ViewHistoryDetailsDto>>.Success(viewHistoryDtos);
            }
            catch (Exception ex)
            {
                return CResult<List<ViewHistoryDetailsDto>>.Failure($"Error getting view history: {ex.Message}");
            }
        }
    }
}