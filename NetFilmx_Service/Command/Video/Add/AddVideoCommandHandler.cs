using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Add
{
    public sealed class AddVideoCommandHandler : ICommandHandler<AddVideoCommand>
    {
        private readonly IVideoRepository _repository;

        public AddVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddVideoCommand command)
        {
            var validation = new AddVideoCommandValidator().Validate(command);
            if(!validation.IsValid)
            {
                return Result.Fail(validation);
            }

           // var isExist = _repository.IsVideoExist();
           // I don't check if video exists, because we can have multiple videos with exact title


            var video = new NetFilmx_Storage.Entities.Video(command.Title, command.Description, command.Price, command.Video_url, command.Thumbnail_url);

            _repository.AddVideo(video);

            return Result.Ok();


        }

    }
}
