using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoCategory.Add
{
    public sealed class AddVideoCategoryCommand : ICommand
    {

        public int Video_Id { get; }

        public int Category_Id { get; }


    }
}
