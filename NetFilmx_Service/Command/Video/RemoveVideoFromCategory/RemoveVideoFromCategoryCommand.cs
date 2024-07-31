using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromCategory
{
    public sealed class RemoveVideoFromCategoryCommand : ICommand
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
