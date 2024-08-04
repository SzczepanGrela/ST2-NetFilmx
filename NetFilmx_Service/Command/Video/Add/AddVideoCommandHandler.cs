using MediatR;
using NetFilmx_Storage.Repositories;
using System.Text.RegularExpressions;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public AddVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddVideoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new AddVideoCommandValidator().Validate(command);
            if (!validation.IsValid)
            {
                return CResult.Fail(validation);
            }


            string ytVideoId = ExtractYouTubeVideoId(command.VideoUrl);
            if (string.IsNullOrEmpty(ytVideoId))
            {
                return CResult.Fail("Invalid YouTube URL");
            }



            var video = new NetFilmx_Storage.Entities.Video(command.Title, command.Description, command.Price, ytVideoId, command.ThumbnailUrl);

            try
            {
                await _repository.AddVideoAsync(video);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }



        }

        public string ExtractYouTubeVideoId(string url)
        {
            if (string.IsNullOrEmpty(url))
                return string.Empty;

            var ytRegex = new Regex(@"(?:https?:\/\/)?(?:www\.)?(youtube\.com|youtu\.be)(\/watch\?v=|\/)([^&]+)?");
            var isYtLink = ytRegex.Match(url);

            if (isYtLink.Success)
            {
                return isYtLink.Groups[3].Value;
            }
            else
            {
                var linkRegex = new Regex(@"(www|http|https|\.com|\.net|\.org)");
                var isLink = linkRegex.IsMatch(url);

                return isLink ? string.Empty : url;
            }
        }

    }
}
