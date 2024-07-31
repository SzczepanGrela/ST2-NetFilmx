using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetCountByName
{
    public sealed class GetTagCountByNameQuery<TDto> : IQuery<TDto>
    {
        public GetTagCountByNameQuery(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; }

    }
}
