using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;



namespace NetFilmx_Service.Query.Category.GetById
{
    public sealed class GetCategoryByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public int Id { get; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
