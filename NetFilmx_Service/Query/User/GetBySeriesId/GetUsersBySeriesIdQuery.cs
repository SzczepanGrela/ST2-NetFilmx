﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetBySeriesId
{
    public sealed class GetUsersBySeriesIdQuery<TDto> : IQuery<List<TDto>>
    {
        public GetUsersBySeriesIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
        public int SeriesId { get; }

   
    }
}
