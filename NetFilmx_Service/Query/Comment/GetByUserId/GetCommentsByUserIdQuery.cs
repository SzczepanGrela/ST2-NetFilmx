using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Comment.GetByUserId
{
    public sealed class GetCommentsByUserIdQuery<TDto> : IQuery<TDto>
    {
        public GetCommentsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
