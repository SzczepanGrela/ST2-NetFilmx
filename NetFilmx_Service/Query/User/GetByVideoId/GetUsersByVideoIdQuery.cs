using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByVideoId
{
    public sealed class GetUsersByVideoIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetUsersByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
