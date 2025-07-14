using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.ViewHistory.Record
{
    public class RecordViewingProgressCommandHandler : IRequestHandler<RecordViewingProgressCommand, CResult>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;

        public RecordViewingProgressCommandHandler(
            IViewHistoryRepository viewHistoryRepository,
            IUserRepository userRepository,
            IVideoRepository videoRepository)
        {
            _viewHistoryRepository = viewHistoryRepository;
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        public async Task<CResult> Handle(RecordViewingProgressCommand request, CancellationToken cancellationToken)
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

                // Validate progress values
                if (request.ProgressSeconds < 0 || request.DurationSeconds <= 0 || request.ProgressSeconds > request.DurationSeconds)
                {
                    return CResult.Failure("Invalid progress values");
                }

                // Record or update viewing progress
                await _viewHistoryRepository.UpdateWatchProgressAsync(
                    request.UserId, 
                    request.VideoId, 
                    request.ProgressSeconds, 
                    request.DurationSeconds);

                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error recording viewing progress: {ex.Message}");
            }
        }
    }
}