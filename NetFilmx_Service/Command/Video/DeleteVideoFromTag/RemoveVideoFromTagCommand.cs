using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromTagCommand : IRequest<CResult>
    {

        public RemoveVideoFromTagCommand(int tagid, int videoid)
        {
            TagId = tagid;
            VideoId = videoid;
        }

        public int TagId { get; }

        public int VideoId { get; }

    }
}
