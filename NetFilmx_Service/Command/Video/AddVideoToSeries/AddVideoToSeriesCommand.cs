using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.AddVideoToSeries
{
    public sealed class AddVideoToSeriesCommand : ICommand
    {
        public int SeriesId { get; set; }

        public int VideoId { get; set; }
    }
}
