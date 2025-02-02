﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Like
{
    public sealed class GetLikesCountByVideoIdQuery : IRequest<QResult<int>>
    {
        public GetLikesCountByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
