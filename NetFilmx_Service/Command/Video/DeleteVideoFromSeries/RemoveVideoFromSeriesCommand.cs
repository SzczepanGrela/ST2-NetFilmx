using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromSeriesCommand : IRequest<CResult>
    {


        public RemoveVideoFromSeriesCommand(int seriesid, int videoid)
        {   SeriesId = seriesid;
            VideoId = videoid;
        }

        public int SeriesId { get; }

        public int VideoId { get; }

    }
}
