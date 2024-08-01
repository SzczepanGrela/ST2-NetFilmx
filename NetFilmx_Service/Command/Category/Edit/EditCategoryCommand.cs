using NetFilmx_Service.Command.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Category
{
    public sealed class EditCategoryCommand : IRequest<CResult>
    {

        public EditCategoryCommand(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name { get;}
        public string? Description { get;}

        public int Id { get;}


    }
}
