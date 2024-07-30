using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetById
{
    public sealed class GetUserByIdQuery : IQuery
    {
        public int UserId { get; }

    }
}
