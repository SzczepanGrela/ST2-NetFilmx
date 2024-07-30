using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetByVideoId
{
    public sealed class GetSeriesByVideoIdQuery : IQuery
    {
        public int VideoId { get; }
    }
}
