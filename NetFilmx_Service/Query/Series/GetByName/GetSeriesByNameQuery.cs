using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetByName
{
    public sealed class GetSeriesByNameQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetSeriesByNameQuery(string seriesName)
        {
            SeriesName = seriesName;
        }
        public string SeriesName { get; }
    }
}
