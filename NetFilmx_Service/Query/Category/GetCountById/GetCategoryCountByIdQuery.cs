using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountById
{
    public sealed class GetCategoryCountByIdQuery: IRequest<QResult<int>>
    {
        public GetCategoryCountByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }
    }
}
