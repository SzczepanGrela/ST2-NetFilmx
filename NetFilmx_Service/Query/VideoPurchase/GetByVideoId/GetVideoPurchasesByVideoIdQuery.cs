﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchasesByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideoPurchasesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
