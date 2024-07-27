using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Delete
{
    public sealed class DeleteVideoCommandHandler : ICommandHandler<DeleteVideoCommand>
    {

        private readonly IVideoRepository _repository;

        public DeleteVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public Result Handle(DeleteVideoCommand command)
        {
            var video = _repository.GetVideoById(command.Id);
            if(video == null)
            {
                return Result.Fail("Video not found");
            }

            _repository.DeleteVideo(command.Id);

            return Result.Ok();
        }

    }
}
