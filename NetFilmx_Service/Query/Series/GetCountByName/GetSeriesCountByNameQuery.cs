using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetCountByName
{
    public sealed class GetSeriesCountByNameQuery : IRequest<QResult<int>>
    {
        public GetSeriesCountByNameQuery(string seriesName)
        {
            SeriesName = seriesName;
        }
        public string SeriesName { get; }

    }
}
