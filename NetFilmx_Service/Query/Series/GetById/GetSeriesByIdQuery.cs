using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetById
{
    public sealed class GetSeriesByIdQuery<TDto> : IQuery<TDto>
    {
        public GetSeriesByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }
    }
}
