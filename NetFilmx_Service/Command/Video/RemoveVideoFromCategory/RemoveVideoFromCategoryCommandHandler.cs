using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromCategory
{
    public sealed class RemoveVideoFromCategoryCommandHandler : ICommandHandler<RemoveVideoFromCategoryCommand>
    {
        private readonly IVideoRepository _repository;

        public RemoveVideoFromCategoryCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }


        public CResult Handle(RemoveVideoFromCategoryCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                _repository.RemoveVideoFromCategory(command.VideoId, command.CategoryId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            
        }


    }
}
