using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Delete
{
    public sealed class DeleteCategoryCommand : ICommand
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}

    }
}
