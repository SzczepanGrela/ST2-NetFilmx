using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetCommentsByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetCommentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
