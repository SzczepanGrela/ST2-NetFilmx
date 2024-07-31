using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Category.GetAll
{
    public sealed class GetAllCategoriesQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetAllCategoriesQuery() { }
    }
}
