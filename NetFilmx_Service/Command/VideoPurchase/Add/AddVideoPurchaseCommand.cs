using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public sealed class AddVideoPurchaseCommand : IRequest<CResult>
    {

        public AddVideoPurchaseCommand(int userid, int videoid)
        {
            UserId = userid;
            VideoId = videoid;
        }

        public int UserId { get; }

        public int VideoId { get; }




    }
}
