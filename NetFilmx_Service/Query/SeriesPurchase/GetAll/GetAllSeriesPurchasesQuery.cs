using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetAll
{
    public sealed class GetAllSeriesPurchasesQuery<TDto> : IQuery<List<TDto>>
    {
        public GetAllSeriesPurchasesQuery() { }
        
    }
}
