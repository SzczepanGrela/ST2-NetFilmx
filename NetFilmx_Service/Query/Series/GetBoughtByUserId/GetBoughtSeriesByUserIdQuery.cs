using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetPurchasedSeriesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetPurchasedSeriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
