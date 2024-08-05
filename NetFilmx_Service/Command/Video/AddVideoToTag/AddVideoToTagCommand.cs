using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToTagCommand : IRequest<CResult>
    {

        public AddVideoToTagCommand(int tagId, int videoId)
        {
            TagId = tagId;
            VideoId = videoId;
        }

        public int TagId { get; }

        public int VideoId { get; }

    }
}
