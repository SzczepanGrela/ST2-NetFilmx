using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByCommentIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetVideoByCommentIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }

    }
}
