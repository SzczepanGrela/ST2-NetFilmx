using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Edit
{
    public sealed class EditVideoCommandHandler : ICommandHandler<EditVideoCommand>
    {
        private readonly IVideoRepository _repository;

        public EditVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public Result Handle(EditVideoCommand command)
        {
            var validation = new EditVideoCommandValidator().Validate(command);
            if (!validation.IsValid)
            {
                return Result.Fail(validation);
            }

            var video = _repository.GetVideoById(command.Id);
            if (video==null)
            {
                return Result.Fail("Video not found");
            }

            video.Price = command.Price;
            video.Title = command.Title;
            video.Description = command.Description;
            video.Video_url = command.Video_url;
            video.Thumbnail_url = command.Thumbnail_url;

            _repository.EditVideo(video);
            return Result.Ok();
        }

     
    }
    
}
