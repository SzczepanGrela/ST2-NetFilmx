using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.AddVideoToCategory
{
    public sealed class AddVideoToCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
        public int VideoId { get; set; }
    }
}
