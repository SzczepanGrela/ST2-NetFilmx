﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetBoughtSeriesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetBoughtSeriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
