using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetBySeriesId
{
    public sealed class GetSeriesPurchasesBySeriesIdQuery : IQuery
    {
        public int SeriesId { get; }

    }
}
