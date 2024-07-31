using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetAll
{
    public sealed class GetAllUsersQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
       
        public GetAllUsersQuery() { }
    }
}
