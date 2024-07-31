using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class EditTagCommand : ICommand
    {

        public EditTagCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
       
        public int Id { get;}
        public string Name { get;}


    }
}
