using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToSeriesCommand : IRequest<CResult>
    {

        public AddVideoToSeriesCommand(int seriesId, int videoId)
        {
            SeriesId = seriesId;
            VideoId = videoId;
        }
        public int SeriesId { get; set; }

        public int VideoId { get; set; }
    }
}
