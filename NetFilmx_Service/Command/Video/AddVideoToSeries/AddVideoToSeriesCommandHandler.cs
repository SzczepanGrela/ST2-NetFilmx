using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToSeriesCommandHandler : IRequestHandler<AddVideoToSeriesCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public AddVideoToSeriesCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }


        public async Task<CResult> Handle(AddVideoToSeriesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.AddVideoToSeriesAsync(command.VideoId, command.SeriesId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }

    }
}
