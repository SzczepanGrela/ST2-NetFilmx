using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByCommentId
{
    public sealed class GetVideoByCommentIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetVideoByCommentIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }

    }
}
