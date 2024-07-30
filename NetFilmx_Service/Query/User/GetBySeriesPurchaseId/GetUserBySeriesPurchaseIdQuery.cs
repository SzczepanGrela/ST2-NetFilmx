using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetBySeriesPurchaseId
{
    public sealed class GetUserBySeriesPurchaseIdQuery : IQuery
    {
        public int SeriesPurchaseId { get; }

    }
}
