using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Add
{
    public sealed class AddCategoryCommand : ICommand
    {

        public string Name { get;} = "default name";
        public string? Description { get;} = "-";
       
    }
}
