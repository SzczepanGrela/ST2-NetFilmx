using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class AddSeriesPurchaseCommandHandler : IRequestHandler<AddSeriesPurchaseCommand, CResult>
    {
        private readonly ISeriesPurchaseRepository _repository;

        public AddSeriesPurchaseCommandHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddSeriesPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var seriesPurchase = new NetFilmx_Storage.Entities.SeriesPurchase(command.UserId, command.SeriesId);
            try
            {
                await _repository.AddSeriesPurchaseAsync(seriesPurchase);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }

    }
}
