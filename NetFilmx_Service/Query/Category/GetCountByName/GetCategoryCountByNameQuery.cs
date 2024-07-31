using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountByName
{
    public sealed class GetCategoryCountByNameQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetCategoryCountByNameQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
        public string CategoryName { get; }

    }
}
