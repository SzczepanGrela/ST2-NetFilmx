﻿using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoFromSeriesCommandHandler : IRequestHandler<RemoveVideoFromSeriesCommand, CResult>
    {

        private readonly IVideoRepository _repository;

        public DeleteVideoFromSeriesCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(RemoveVideoFromSeriesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
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
