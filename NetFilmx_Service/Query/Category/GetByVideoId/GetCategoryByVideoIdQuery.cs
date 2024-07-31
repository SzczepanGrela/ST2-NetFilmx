using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetByVideoId
{
    public sealed class GetCategoryByVideoIdQuery<TDto> : IQuery<List<TDto>>
    {
        public GetCategoryByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
