using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Series
{
    public sealed class DeleteSeriesCommandHandler : IRequestHandler<DeleteSeriesCommand, CResult>
    {
        private readonly ISeriesRepository _repository;


        public DeleteSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(DeleteSeriesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                await _repository.DeleteSeriesAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }

    }
}
