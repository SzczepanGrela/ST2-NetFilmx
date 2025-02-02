﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchasesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideoPurchasesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
