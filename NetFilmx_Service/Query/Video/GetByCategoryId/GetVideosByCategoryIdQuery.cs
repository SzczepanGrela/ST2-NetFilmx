using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByCategoryId
{
    public sealed class GetVideosByCategoryIdQuery<TDto> : IQuery<QResult<TDto>>
    {
        public GetVideosByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }

      
    }
}
