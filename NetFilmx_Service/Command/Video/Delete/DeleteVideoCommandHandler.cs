using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, CResult>
    {

        private readonly IVideoRepository _repository;

        public DeleteVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(DeleteVideoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                await _repository.DeleteVideoAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }

    }
}
