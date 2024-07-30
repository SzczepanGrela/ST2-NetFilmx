using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetById
{
    public sealed class GetCommentByIdQuery : IQuery
    {
        public int CommentId { get; }
    }
}
