using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoTag.Add
{
    public sealed class AddVideoTagCommandValidator : AbstractValidator<AddVideoTagCommand>
    {

        public AddVideoTagCommandValidator()
        {
            RuleFor(x => x.Video_Id).NotEmpty();
            RuleFor(x => x.Tag_Id).NotEmpty();
        }

    }


}
