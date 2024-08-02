using MediatR;
using NetFilmx_Service.Dtos.User;
using System.Collections.Generic;

namespace NetFilmx_Service.Query.User
{
    public class GetUsersByExcludedVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    where TDto : IUserDto
    {
        public GetUsersByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }

        public int VideoId { get; }
    }
}
