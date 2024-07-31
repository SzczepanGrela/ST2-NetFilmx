using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetById
{
    public sealed class GetVideoByIdQuery<TDto> : IQuery<TDto>
    {

        public GetVideoByIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

      
    }
}
