using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetCountById
{
    public sealed class GetSeriesCountByIdQuery : IQuery
    {
        public int SeriesId { get; }

    }
}
