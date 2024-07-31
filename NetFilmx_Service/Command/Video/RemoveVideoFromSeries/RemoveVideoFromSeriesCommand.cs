using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromSeriesCommand : ICommand
    {


        public RemoveVideoFromSeriesCommand(int seriesid, int videoid)
        {   SeriesId = seriesid;
            VideoId = videoid;
        }

        public int SeriesId { get; }

        public int VideoId { get; }

    }
}
