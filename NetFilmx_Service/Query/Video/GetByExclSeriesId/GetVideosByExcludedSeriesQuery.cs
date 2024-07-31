﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Video.GetByExclSeriesId
{
    public sealed class GetVideosByExcludedSeriesQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideosByExcludedSeriesQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }
    }
}
