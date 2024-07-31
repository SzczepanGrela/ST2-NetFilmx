using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

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
