using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetByLikeId
{
    public sealed class GetVideoByLikeIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetVideoByLikeIdQuery(int likeId)
        {
            LikeId = likeId;
        }
        public int LikeId { get; }

    }
}
