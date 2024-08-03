using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoFromTagCommandHandler : IRequestHandler<RemoveVideoFromTagCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public DeleteVideoFromTagCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }

        public async Task<CResult> Handle(RemoveVideoFromTagCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.RemoveVideoFromTagAsync(command.VideoId, command.TagId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }


    }
}
