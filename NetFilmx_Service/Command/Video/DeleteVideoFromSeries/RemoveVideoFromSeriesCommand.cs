using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromSeriesCommand : IRequest<CResult>
    {


        public RemoveVideoFromSeriesCommand(int seriesid, int videoid)
        {
            SeriesId = seriesid;
            VideoId = videoid;
        }

        public int SeriesId { get; }

        public int VideoId { get; }

    }
}
