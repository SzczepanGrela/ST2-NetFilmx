using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetById
{
    public sealed class GetSeriesPurchaseByIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetSeriesPurchaseByIdQuery(int seriesPurchaseId)
        {
            SeriesPurchaseId = seriesPurchaseId;
        }
        public int SeriesPurchaseId { get; }

      
    }
}
