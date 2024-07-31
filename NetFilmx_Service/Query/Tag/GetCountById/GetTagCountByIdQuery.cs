using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetCountById
{
    public sealed class GetTagCountByIdQuery<TDto> : IQuery<TDto>
    {
        public GetTagCountByIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
