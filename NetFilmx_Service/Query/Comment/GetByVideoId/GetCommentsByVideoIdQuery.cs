using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetCommentsByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetCommentsByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }
    }
}
