﻿using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByCategoryIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetVideosByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }


    }
}
