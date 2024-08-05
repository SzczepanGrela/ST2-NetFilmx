using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromTagCommand : IRequest<CResult>
    {

        public RemoveVideoFromTagCommand(int tagid, int videoid)
        {
            TagId = tagid;
            VideoId = videoid;
        }

        public int TagId { get; }

        public int VideoId { get; }

    }
}
