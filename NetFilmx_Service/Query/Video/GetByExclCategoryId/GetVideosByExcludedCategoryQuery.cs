using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByExclCategoryId
{
    public sealed class GetVideosByExcludedCategoryQuery<TDto> : IQuery<TDto>
    {
      
        public GetVideosByExcludedCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }

    }
}
