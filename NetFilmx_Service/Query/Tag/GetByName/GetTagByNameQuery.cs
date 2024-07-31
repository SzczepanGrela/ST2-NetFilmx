using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetByName
{
    public sealed class GetTagByNameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetTagByNameQuery(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; }

    }
}
