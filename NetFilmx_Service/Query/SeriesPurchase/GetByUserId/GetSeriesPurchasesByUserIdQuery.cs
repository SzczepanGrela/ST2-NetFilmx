using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetByUserId
{
    public sealed class GetSeriesPurchasesByUserIdQuery : IQuery
    {
        public int UserId { get; }

    }
}
