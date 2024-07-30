using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.RemoveVideoFromTag
{
    public sealed class RemoveVideoFromTagCommand : ICommand
    {
        public int TagId { get; }

        public int VideoId { get; }

    }
}
