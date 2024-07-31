using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromSeries
{
    public sealed class RemoveVideoFromSeriesCommandHandler : ICommandHandler<RemoveVideoFromSeriesCommand>
    {

        private readonly IVideoRepository _repository;

        public RemoveVideoFromSeriesCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(RemoveVideoFromSeriesCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.RemoveVideoFromSeriesAsync(command.VideoId, command.SeriesId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            
        }

    }
}
