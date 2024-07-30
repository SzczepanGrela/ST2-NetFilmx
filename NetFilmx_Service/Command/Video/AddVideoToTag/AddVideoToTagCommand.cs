using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.AddVideoToTag
{
    public sealed class AddVideoToTagCommand : ICommand
    {
        public int TagId { get;}

        public int VideoId { get;}

    }
}
