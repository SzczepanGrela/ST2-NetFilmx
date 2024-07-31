using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByNameQuery: IRequest<QResult<int>>
    {
        public GetTagCountByNameQuery(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; }

    }
}
