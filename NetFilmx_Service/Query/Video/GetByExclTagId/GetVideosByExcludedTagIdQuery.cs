﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedTagIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosByExcludedTagIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
