using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoSeries.Add
{
    public sealed class AddVideoSeriesCommand : ICommand
    {

        public int Video_Id { get; }

        public int Series_Id { get; }

    }
}
