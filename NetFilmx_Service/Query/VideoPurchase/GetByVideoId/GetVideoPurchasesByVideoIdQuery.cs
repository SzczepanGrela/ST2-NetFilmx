using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetByVideoId
{
    public sealed class GetVideoPurchasesByVideoIdQuery : IQuery
    {
        public int VideoId { get; }

    }
}
