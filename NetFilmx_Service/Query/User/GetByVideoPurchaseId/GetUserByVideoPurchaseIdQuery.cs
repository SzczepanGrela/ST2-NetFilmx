using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByVideoPurchaseId
{
    public sealed class GetUserByVideoPurchaseIdQuery : IQuery
    {
        public int VideoPurchaseId { get; }

    }
}
