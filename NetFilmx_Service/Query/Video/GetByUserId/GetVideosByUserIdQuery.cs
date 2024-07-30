using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByUserId
{
    public sealed class GetVideosByUserIdQuery : IQuery
    {
        public int UserId { get; }


    }
}
