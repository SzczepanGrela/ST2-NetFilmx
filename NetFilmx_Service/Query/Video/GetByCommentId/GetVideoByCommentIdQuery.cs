﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByCommentId
{
    public sealed class GetVideoByCommentIdQuery : IQuery
    {
        public int CommentId { get; }

    }
}
