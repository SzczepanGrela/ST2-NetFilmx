using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Series.GetCountById
{
    public sealed class GetSeriesCountByIdQuery : IRequest<QResult<int>>
    {
        public GetSeriesCountByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
