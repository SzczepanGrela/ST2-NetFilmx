using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByUserId
{
    public sealed class GetVideosByUserIdQuery<TDto> : IQuery<TDto>
    {

        public GetVideosByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }


    }
}
