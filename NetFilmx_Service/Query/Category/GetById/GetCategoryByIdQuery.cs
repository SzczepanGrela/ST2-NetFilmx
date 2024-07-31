using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetById
{
    public sealed class GetCategoryByIdQuery : IQuery
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get;}

    }
}
