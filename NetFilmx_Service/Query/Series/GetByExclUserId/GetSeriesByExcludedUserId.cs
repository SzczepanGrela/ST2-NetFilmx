using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByExcludedUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {


        public GetSeriesByExcludedUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }

    }
}
