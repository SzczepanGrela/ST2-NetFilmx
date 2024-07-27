using NetFilmx_Service.Command.Category.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Edit
{
    public sealed class EditCategoryCommand : ICommand
    {

        public string Name { get; set; }
        public string? Description { get; set; }

        public int Id { get; set; }


    }
}
