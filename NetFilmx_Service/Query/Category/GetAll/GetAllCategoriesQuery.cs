using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Category;

namespace NetFilmx_Service.Query.Category.GetAll
{
    public sealed class GetAllCategoriesQuery<TDto> : IRequest<QResult<List<TDto>>>  
        where TDto : ICategoryDto 
    {
        public GetAllCategoriesQuery() { }
    }

}
