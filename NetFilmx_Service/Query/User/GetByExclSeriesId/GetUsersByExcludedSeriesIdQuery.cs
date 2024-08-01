using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User
{
    public class GetUsersByExcludedSeriesIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetUsersByExcludedSeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
