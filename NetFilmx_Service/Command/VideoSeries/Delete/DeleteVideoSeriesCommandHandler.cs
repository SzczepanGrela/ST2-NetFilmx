using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoSeries.Delete
{
    public sealed class DeleteVideoSeriesCommandHandler : ICommandHandler<DeleteVideoSeriesCommand>
    {
        private readonly IVideoSeriesRepository _repository;

        public DeleteVideoSeriesCommandHandler(IVideoSeriesRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteVideoSeriesCommand command)
        {
            var videoSeries = _repository.GetVideoSeriesByVideoIdSeriesId(command.Video_Id, command.Series_Id);

            if (videoSeries == null)
            {
                return Result.Fail("Connection between this Video and Series does not exist");
            }

            _repository.DeleteVideoSeries(videoSeries.Id);

            return Result.Ok();
        }
    }
}
