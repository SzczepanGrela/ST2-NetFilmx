using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToTagCommandHandler : ICommandHandler<AddVideoToTagCommand>
    {
        private readonly IVideoRepository _repository;

        public AddVideoToTagCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }

        public async Task<CResult> Handle(AddVideoToTagCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                await _repository.AddVideoToTagAsync(command.VideoId, command.TagId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
