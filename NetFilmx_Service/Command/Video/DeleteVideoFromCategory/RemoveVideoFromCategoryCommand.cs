using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromCategoryCommand : IRequest<CResult>
    {

        public RemoveVideoFromCategoryCommand(int categoryId, int videoId)
        {
            CategoryId = categoryId;
            VideoId = videoId;
        }

        public int CategoryId { get; }

        public int VideoId { get; }
    }
}
