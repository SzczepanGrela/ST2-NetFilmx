using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideosByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }


    }
}
