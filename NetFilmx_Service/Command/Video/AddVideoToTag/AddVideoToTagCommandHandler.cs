using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.AddVideoToTag
{
    public sealed class AddVideoToTagCommandHandler : ICommandHandler<AddVideoToTagCommand>
    {
        private readonly IVideoRepository _repository;

        public AddVideoToTagCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }

        public CResult Handle(AddVideoToTagCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                _repository.AddVideoToTag(command.VideoId, command.TagId);
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            return CResult.Ok();
        }

    }
}
