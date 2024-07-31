using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetBySeriesId
{
    public sealed class GetVideosBySeriesIdQuery<TDto> : IQuery<QResult<TDto>>
    {

        public GetVideosBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
