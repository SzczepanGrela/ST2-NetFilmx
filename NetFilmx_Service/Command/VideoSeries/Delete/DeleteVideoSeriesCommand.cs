using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoSeries.Delete
{
    public sealed class DeleteVideoSeriesCommand : ICommand
    {   
        public int Video_Id { get; }

        public int Series_Id { get; }
    }
}
