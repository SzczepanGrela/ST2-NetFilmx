using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByUsernameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
        public string Username { get; }

    }
}
