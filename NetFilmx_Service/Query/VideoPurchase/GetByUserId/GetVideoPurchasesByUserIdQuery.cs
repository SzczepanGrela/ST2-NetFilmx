using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchasesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {

        public GetVideoPurchasesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
