﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoriesByExcludedVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetCategoriesByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }

        public int VideoId { get; }


    }
}
