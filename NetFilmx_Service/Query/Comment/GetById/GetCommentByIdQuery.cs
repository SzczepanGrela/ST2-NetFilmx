using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetById
{
    public sealed class GetCommentByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetCommentByIdQuery(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; }
    }
}
