﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetAllSeriesPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetAllSeriesPurchasesQuery() { }
        
    }
}
