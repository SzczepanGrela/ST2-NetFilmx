using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchasesByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideoPurchasesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
