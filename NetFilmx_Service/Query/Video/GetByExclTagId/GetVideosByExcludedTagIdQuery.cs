﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByExclTagId
{
    public sealed class GetVideosByExcludedTagIdQuery<TDto> : IQuery<List<TDto>>
    {

        public GetVideosByExcludedTagIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
