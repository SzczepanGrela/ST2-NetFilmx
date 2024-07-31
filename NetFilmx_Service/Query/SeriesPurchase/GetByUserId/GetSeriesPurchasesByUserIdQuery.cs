using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetByUserId
{
    public sealed class GetSeriesPurchasesByUserIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetSeriesPurchasesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
