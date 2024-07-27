using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoTag.Delete
{
    public sealed class DeleteVideoTagCommand : ICommand
    {
        public int Video_Id { get; }

        public int Tag_Id { get; }


    }
}
