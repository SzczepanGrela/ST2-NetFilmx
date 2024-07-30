using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromTag
{
    public sealed class RemoveVideoFromTagCommandHandler : ICommandHandler<RemoveVideoFromTagCommand>
    {
        private readonly IVideoRepository _repository;

        public RemoveVideoFromTagCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }

        public CResult Handle(RemoveVideoFromTagCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                _repository.RemoveVideoFromTag(command.VideoId, command.TagId);
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            return CResult.Ok();
        }


    }
}
