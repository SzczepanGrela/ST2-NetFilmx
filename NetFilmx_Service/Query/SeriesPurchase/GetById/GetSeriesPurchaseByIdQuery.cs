using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchaseByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetSeriesPurchaseByIdQuery(int seriesPurchaseId)
        {
            SeriesPurchaseId = seriesPurchaseId;
        }
        public int SeriesPurchaseId { get; }

      
    }
}
