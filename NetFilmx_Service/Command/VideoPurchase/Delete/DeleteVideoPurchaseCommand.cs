﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoPurchase.Delete
{
    public class DeleteVideoPurchaseCommand : ICommand
    {


        public DeleteVideoPurchaseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

      
    }
}
