using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetByVideoId
{
    public sealed class GetTagsByVideoIdQuery : IQuery
    {
        public int VideoId { get; }

    }
}
