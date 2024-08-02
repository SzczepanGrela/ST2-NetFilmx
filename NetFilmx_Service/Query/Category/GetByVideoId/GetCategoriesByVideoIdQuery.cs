using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoriesByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetCategoriesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
