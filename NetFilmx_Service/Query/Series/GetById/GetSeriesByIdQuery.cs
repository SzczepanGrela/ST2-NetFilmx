using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetById
{
    public sealed class GetSeriesByIdQuery : IQuery
    {
        public int SeriesId { get; }
    }
}
