using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoSeries.Add
{
    public sealed class AddVideoSeriesCommandValidator : AbstractValidator<AddVideoSeriesCommand>
    {
        public AddVideoSeriesCommandValidator()
        {
            RuleFor(x => x.Video_Id).NotEmpty();
            RuleFor(x => x.Series_Id).NotEmpty();
        }
    }
}
