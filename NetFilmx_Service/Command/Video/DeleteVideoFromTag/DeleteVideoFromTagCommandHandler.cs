using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoFromTagCommandHandler : IRequestHandler<DeleteVideoFromTagCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public DeleteVideoFromTagCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }

        public async Task<CResult> Handle(DeleteVideoFromTagCommand command, CancellationToken cancellationToken)
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
