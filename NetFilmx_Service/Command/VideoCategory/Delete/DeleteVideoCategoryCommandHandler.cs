using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoCategory.Delete
{
    public sealed class DeleteVideoCategoryCommandHandler : ICommandHandler<DeleteVideoCategoryCommand>
    {

        private readonly IVideoCategoryRepository _repository;

        public DeleteVideoCategoryCommandHandler(IVideoCategoryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteVideoCategoryCommand command)
        {

            var VideoCategory = _repository.GetVideoCategoryByVideoIdCategoryId(command.video_id, command.category_id);

            if (VideoCategory == null)
            {
                return Result.Fail("Connection between this Video and Category does not exist");
            }

            _repository.DeleteVideoCategory(VideoCategory.Id);

            return Result.Ok();
        }

    
    }
}
