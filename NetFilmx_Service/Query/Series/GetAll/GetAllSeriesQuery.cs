using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetAll
{
    public sealed class GetAllSeriesQuery<TDto> : IQuery<List<TDto>>
    {
        public GetAllSeriesQuery() { }

    }
}
