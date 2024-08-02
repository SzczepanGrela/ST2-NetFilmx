﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByExcludedVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {


        public GetSeriesByExcludedVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }

        public int VideoId { get; }

    }
}
