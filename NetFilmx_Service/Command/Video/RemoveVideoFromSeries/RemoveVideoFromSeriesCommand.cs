using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromSeries
{
    public sealed class RemoveVideoFromSeriesCommand : ICommand
    {
        public int SeriesId { get; }

        public int VideoId { get; }

    }
}
