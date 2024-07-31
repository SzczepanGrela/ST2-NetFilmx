using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetByTagId
{
    public sealed class GetVideosByTagIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideosByTagIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
