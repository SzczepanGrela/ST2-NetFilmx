﻿using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByLikeIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByLikeIdQuery(int likeId)
        {
            LikeId = likeId;
        }
        public int LikeId { get; }
    }
}
