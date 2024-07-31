using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetBoughtByUserId
{
    public sealed class GetBoughtSeriesByUserIdQuery : IQuery
    {
        public GetBoughtSeriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
