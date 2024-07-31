using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetAll
{
    public sealed class GetAllCommentsQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetAllCommentsQuery() { }
    }
}
