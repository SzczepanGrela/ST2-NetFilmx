using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.User.GetByVideoPurchaseId
{
    public sealed class GetUserByVideoPurchaseIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByVideoPurchaseIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }
        public int VideoPurchaseId { get; }

    }
}
