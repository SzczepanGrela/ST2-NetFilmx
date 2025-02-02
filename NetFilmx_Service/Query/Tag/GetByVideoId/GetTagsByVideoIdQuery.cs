﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagsByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetTagsByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
