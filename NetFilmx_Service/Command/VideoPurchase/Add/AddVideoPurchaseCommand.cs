using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoPurchase.Add
{
    public sealed class AddVideoPurchaseCommand : ICommand
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
