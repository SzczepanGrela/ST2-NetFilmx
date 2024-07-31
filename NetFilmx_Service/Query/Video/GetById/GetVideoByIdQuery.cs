using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetById
{
    public sealed class GetVideoByIdQuery<TDto> : IRequest<QResult<TDto>>
    {

        public GetVideoByIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

      
    }
}
