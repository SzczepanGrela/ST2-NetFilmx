using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoPurchase.Add
{
    public sealed class AddVideoPurchaseCommand : ICommand
    {
        public int UserId { get; }

        public int VideoId { get; }


    }
}
