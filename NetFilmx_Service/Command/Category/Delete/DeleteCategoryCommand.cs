using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Category
{
    public sealed class DeleteCategoryCommand : IRequest<CResult>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}

    }
}
