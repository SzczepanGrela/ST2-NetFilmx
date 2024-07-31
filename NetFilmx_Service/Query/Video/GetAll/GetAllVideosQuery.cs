using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetAll
{
    public sealed class GetAllVideosQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        
        public GetAllVideosQuery() { }
    }
}
