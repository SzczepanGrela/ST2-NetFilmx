using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Add
{
    public sealed class AddTagCommand : ICommand
    {
         
        public AddTagCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
