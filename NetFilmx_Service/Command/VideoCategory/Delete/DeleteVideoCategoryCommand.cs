using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoCategory.Delete
{
    public sealed class DeleteVideoCategoryCommand : ICommand
    {
        public int video_id { get; }

        public int category_id { get; }

    }
}
