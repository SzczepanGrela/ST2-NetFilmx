using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetBySeriesId
{
    public sealed class GetSeriesPurchasesBySeriesIdQuery<TDto> : IQuery<TDto>
    {
        public GetSeriesPurchasesBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

    }
}
