using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByLikeIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByLikeIdQuery(int likeId)
        {
            LikeId = likeId;
        }
        public int LikeId { get; }
    }
}
