using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetByVideoId
{
    public sealed class GetCategoryByVideoIdQuery : IQuery
    {
        public int VideoId { get; }

    }
}
