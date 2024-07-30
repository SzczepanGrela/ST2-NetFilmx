using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByCommentId
{
    public sealed class GetUserByCommentIdQuery : IQuery
    {
        public int CommentId { get; }

    }
}
