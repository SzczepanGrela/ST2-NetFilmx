﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByLikeId
{
    public sealed class GetVideoByLikeIdQuery : IQuery
    {
        public int LikeId { get; }

    }
}
