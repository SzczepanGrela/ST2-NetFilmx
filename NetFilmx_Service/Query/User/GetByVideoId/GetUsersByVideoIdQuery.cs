using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetUsersByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
