using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetBySeriesId
{
    public sealed class GetVideosBySeriesIdQuery : IQuery
    {
        public int SeriesId { get; }

    }
}
