using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoFromCategoryCommandHandler : IRequestHandler<RemoveVideoFromCategoryCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public DeleteVideoFromCategoryCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }


        public async Task<CResult> Handle(RemoveVideoFromCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.RemoveVideoFromCategoryAsync(command.VideoId, command.CategoryId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }


    }
}
