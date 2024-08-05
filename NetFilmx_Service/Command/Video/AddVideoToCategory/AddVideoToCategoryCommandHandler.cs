using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;


namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToCategoryCommandHandler : IRequestHandler<AddVideoToCategoryCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public AddVideoToCategoryCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddVideoToCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                await _repository.AddVideoToCategoryAsync(command.VideoId, command.CategoryId);
                return CResult.Ok();
            }
            catch
            (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }
    }
}
