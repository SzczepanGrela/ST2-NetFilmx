using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Delete
{
    public sealed class DeleteVideoCommand : ICommand
    {
        public int Id { get; }


    }
}
