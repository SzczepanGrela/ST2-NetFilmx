using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetSeriesByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }
    }
}
