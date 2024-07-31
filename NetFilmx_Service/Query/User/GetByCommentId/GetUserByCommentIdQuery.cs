using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByCommentId
{
    public sealed class GetUserByCommentIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByCommentIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }

    }
}
