using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetAllSeriesQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetAllSeriesQuery() { }

    }
}
