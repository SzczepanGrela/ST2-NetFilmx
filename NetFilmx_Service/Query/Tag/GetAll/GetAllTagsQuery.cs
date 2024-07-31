using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetAllTagsQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        
        public GetAllTagsQuery() { }
    }
}
