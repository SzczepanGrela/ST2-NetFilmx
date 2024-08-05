using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, CResult>
    {


        private readonly ITagRepository _repository;

        public DeleteTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {

            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteTagAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }
    }
}
