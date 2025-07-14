using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.ViewHistory.Delete
{
    public class ClearViewHistoryCommandHandler : IRequestHandler<ClearViewHistoryCommand, CResult>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;
        private readonly IUserRepository _userRepository;

        public ClearViewHistoryCommandHandler(IViewHistoryRepository viewHistoryRepository, IUserRepository userRepository)
        {
            _viewHistoryRepository = viewHistoryRepository;
            _userRepository = userRepository;
        }

        public async Task<CResult> Handle(ClearViewHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult.Failure("User not found");
                }

                // Get all view history for user and delete them
                var userViewHistory = await _viewHistoryRepository.GetByUserIdAsync(request.UserId, int.MaxValue);
                foreach (var viewHistory in userViewHistory)
                {
                    await _viewHistoryRepository.DeleteAsync(viewHistory.Id);
                }
                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error clearing view history: {ex.Message}");
            }
        }
    }
}