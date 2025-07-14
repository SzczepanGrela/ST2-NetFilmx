using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.ViewHistory.Complete
{
    public class MarkVideoCompletedCommandHandler : IRequestHandler<MarkVideoCompletedCommand, CResult>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;

        public MarkVideoCompletedCommandHandler(
            IViewHistoryRepository viewHistoryRepository,
            IUserRepository userRepository,
            IVideoRepository videoRepository)
        {
            _viewHistoryRepository = viewHistoryRepository;
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public async Task<CResult> Handle(MarkVideoCompletedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult.Failure("User not found");
                }

                // Validate video exists
                if (!await _videoRepository.IsVideoExistAsync(request.VideoId))
                {
                    return CResult.Failure("Video not found");
                }

                // Get existing view history or create new one
                var viewHistory = await _viewHistoryRepository.GetByUserAndVideoAsync(request.UserId, request.VideoId);
                
                if (viewHistory == null)
                {
                    // Create a new view history entry marked as completed
                    viewHistory = new NetFilmx_Storage.Entities.ViewHistory(request.UserId, request.VideoId);
                    viewHistory.VideoDurationSeconds = 100; // Default duration
                    viewHistory.WatchTimeSeconds = 100; // Mark as fully watched
                    await _viewHistoryRepository.AddAsync(viewHistory);
                }
                else
                {
                    // Update existing entry to mark as completed
                    if (viewHistory.VideoDurationSeconds.HasValue)
                    {
                        viewHistory.WatchTimeSeconds = viewHistory.VideoDurationSeconds.Value;
                    }
                    else
                    {
                        viewHistory.VideoDurationSeconds = Math.Max(100, viewHistory.WatchTimeSeconds);
                        viewHistory.WatchTimeSeconds = viewHistory.VideoDurationSeconds.Value;
                    }
                    viewHistory.UpdatedAt = DateTime.Now;
                    await _viewHistoryRepository.UpdateAsync(viewHistory);
                }

                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error marking video as completed: {ex.Message}");
            }
        }
    }
}