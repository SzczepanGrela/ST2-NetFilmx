﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Delete
{
    public sealed class DeleteTagCommand : ICommand
    {

        public int Id { get; set; }

    }
}
