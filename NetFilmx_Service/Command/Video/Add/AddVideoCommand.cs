using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Add
{
    public sealed class AddVideoCommand : ICommand
    {

        public string Title { get;}

        public string Description { get;}= "-";

        public decimal Price { get;}

        public string Video_url { get;}

        public string? Thumbnail_url { get;}



    }
}
