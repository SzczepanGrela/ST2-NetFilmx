using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;


namespace NetFilmx_Service.Command.Series
{
    public sealed class AddSeriesCommandHandler : IRequestHandler<AddSeriesCommand, CResult>
    {

        private readonly ISeriesRepository _repository;

        public AddSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddSeriesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            var validationResult = new AddSeriesCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            var series = new NetFilmx_Storage.Entities.Series(command.Name, command.Price, command.Description);
            try
            {
                await _repository.AddSeriesAsync(series);
                return CResult.Ok();

            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }

    }
}
