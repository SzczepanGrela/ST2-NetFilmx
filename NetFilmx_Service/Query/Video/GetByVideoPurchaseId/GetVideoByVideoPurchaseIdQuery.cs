using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByVideoPurchaseId
{
    public sealed class GetVideoByVideoPurchaseIdQuery : IQuery
    {
        public int VideoPurchaseId { get; }

    }
}
