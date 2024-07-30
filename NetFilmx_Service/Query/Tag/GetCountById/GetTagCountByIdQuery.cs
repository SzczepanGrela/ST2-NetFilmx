using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetCountById
{
    public sealed class GetTagCountByIdQuery : IQuery
    {
        public int TagId { get; }

    }
}
