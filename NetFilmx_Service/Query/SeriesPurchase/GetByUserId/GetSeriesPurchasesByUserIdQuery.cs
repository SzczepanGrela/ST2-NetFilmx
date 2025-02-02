﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchasesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetSeriesPurchasesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
