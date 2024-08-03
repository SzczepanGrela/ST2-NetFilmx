using MediatR;
using NetFilmx_Storage.Repositories;
using System.Text.RegularExpressions;

namespace NetFilmx_Service.Command.Video
{
    public sealed class EditVideoCommandHandler : IRequestHandler<EditVideoCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public EditVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(EditVideoCommand command, CancellationToken cancellationToken)
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


            var ytVideoId = ExtractYouTubeVideoId(command.Video_url);


            try
            {
                var video = await _repository.GetVideoByIdAsync(command.Id);

                //var video = task.Result;

                video.Price = command.Price;
                video.Title = command.Title;
                video.Description = command.Description;
                video.VideoUrl = ytVideoId;
                video.ThumbnailUrl = command.Thumbnail_url;
                video.UpdatedAt = DateTime.Now;

                await _repository.UpdateVideoAsync(video);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }

        private string ExtractYouTubeVideoId(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            var regex = new Regex(@"(?:https?:\/\/)?(?:www\.)?youtube\.com\/watch\?v=([^&]+)");
            var match = regex.Match(url);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }



    }

}
