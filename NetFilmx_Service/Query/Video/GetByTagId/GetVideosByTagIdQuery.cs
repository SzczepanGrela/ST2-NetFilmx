using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByTagId
{
    public sealed class GetVideosByTagIdQuery : IQuery
    {
        public int TagId { get; }

    }
}
