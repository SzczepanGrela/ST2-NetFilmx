﻿using NetFilmx_Service.Command.Category.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Edit
{
    public sealed class EditCategoryCommand : ICommand
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
