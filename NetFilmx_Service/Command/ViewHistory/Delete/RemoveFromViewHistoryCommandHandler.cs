using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.ViewHistory.Delete
{
    public class RemoveFromViewHistoryCommandHandler : IRequestHandler<RemoveFromViewHistoryCommand, CResult>
    {
        private readonly IViewHistoryRepository _viewHistoryRepository;

        public RemoveFromViewHistoryCommandHandler(IViewHistoryRepository viewHistoryRepository)
        {
            _viewHistoryRepository = viewHistoryRepository;
        }

        public async Task<CResult> Handle(RemoveFromViewHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _viewHistoryRepository.DeleteAsync(request.ViewHistoryId);
                return CResult.Success();
            }
            catch (ArgumentException ex)
            {
                return CResult.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error removing from view history: {ex.Message}");
            }
        }
    }
}