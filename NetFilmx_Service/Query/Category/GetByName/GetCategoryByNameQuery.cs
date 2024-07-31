using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetByName
{
   public sealed class GetCategoryByNameQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
        public string Name { get; }


    }

}
