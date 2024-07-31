using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetBySeriesId
{
    public sealed class GetVideosBySeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideosBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
