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


        public CResult Handle(EditVideoCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new EditVideoCommandValidator().Validate(command);
            if (!validation.IsValid)
            {
                return CResult.Fail(validation);
            }
            try
            {
                var video = _repository.GetVideoById(command.Id);


                video.Price = command.Price;
                video.Title = command.Title;
                video.Description = command.Description;
                video.VideoUrl = command.Video_url;
                video.ThumbnailUrl = command.Thumbnail_url;

                _repository.UpdateVideo(video);
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            return CResult.Ok();
        }



    }

}
