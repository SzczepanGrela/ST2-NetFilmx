using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagsByExcludedVideoIdQuery<TDto> :  IRequest<QResult<List<TDto>>>
    {
        public GetTagsByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
   
}
