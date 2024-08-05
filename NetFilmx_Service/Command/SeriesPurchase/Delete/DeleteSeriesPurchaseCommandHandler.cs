using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class DeleteSeriesPurchaseCommandHandler : IRequestHandler<DeleteSeriesPurchaseCommand, CResult>
    {
        private readonly ISeriesPurchaseRepository _repository;

        public DeleteSeriesPurchaseCommandHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteSeriesPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            try
            {
                await _repository.DeleteSeriesPurchaseAsync(command.SeriesId, command.UserId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }
    }
}
