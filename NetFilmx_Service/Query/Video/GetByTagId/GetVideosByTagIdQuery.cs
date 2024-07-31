using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByTagId
{
    public sealed class GetVideosByTagIdQuery<TDto> : IQuery<List<TDto>>
    {

        public GetVideosByTagIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
