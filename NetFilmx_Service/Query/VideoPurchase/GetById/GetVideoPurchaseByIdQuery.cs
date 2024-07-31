using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetById
{
    public sealed class GetVideoPurchaseByIdQuery<TDto> : IQuery<QResult<TDto>>
    {

        public GetVideoPurchaseByIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }
        public int VideoPurchaseId { get; }

    }
}
