using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByVideoPurchaseId
{
    public sealed class GetVideoByVideoPurchaseIdQuery<TDto> : IQuery<QResult<TDto>>
    {

        public GetVideoByVideoPurchaseIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }

        public int VideoPurchaseId { get; }

    }
}
