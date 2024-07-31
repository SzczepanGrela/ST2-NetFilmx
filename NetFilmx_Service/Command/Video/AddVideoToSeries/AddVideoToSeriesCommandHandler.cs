﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.AddVideoToSeries
{
    public sealed class AddVideoToSeriesCommandHandler : ICommandHandler<AddVideoToSeriesCommand>
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
