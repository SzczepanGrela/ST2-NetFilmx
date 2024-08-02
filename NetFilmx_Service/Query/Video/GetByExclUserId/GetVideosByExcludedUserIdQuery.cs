using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetVideosByExcludedUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
