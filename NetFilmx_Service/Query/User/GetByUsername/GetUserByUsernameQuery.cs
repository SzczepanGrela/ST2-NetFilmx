using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByUsername
{
    public sealed class GetUserByUsernameQuery : IQuery
    {
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
        public string Username { get; }

    }
}
