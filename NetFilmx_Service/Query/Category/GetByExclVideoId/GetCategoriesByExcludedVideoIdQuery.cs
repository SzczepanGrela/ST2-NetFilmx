using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
