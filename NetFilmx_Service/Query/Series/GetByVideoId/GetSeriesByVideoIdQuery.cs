using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetByVideoId
{
    public sealed class GetSeriesByVideoIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetSeriesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
