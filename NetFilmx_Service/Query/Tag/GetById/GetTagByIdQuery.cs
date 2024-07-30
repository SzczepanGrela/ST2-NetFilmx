using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetById
{
    public sealed class GetTagByIdQuery : IQuery
    {
        public int TagId { get; }

    }
}
