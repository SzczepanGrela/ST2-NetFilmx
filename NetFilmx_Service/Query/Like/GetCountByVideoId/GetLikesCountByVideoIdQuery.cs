using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Like
{
    public sealed class GetLikesCountByVideoIdQuery: IRequest<QResult<int>>
    {
        public GetLikesCountByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
