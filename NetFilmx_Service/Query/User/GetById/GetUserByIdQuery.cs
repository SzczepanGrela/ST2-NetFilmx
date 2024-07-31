using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetById
{
    public sealed class GetUserByIdQuery<TDto> : IQuery<TDto>
    {
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
