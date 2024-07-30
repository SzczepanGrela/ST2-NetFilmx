using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetByName
{
    public sealed class GetTagByNameQuery : IQuery
    {
        public string TagName { get; }

    }
}
