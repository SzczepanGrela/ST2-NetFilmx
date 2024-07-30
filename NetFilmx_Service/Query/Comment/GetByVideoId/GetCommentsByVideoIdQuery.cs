using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetByVideoId
{
    public sealed class GetCommentsByVideoIdQuery : IQuery
    {
        public int VideoId { get; }
    }
}
