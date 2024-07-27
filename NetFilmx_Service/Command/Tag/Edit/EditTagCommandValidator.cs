using FluentValidation;
using NetFilmx_Service.Command.Category.Add;
using NetFilmx_Service.Command.Tag.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Edit
{
    internal class EditTagCommandValidator : AbstractValidator<EditTagCommand>
    {

        public int MaxNameLength { get; } = AddTagCommandValidator.MaxNameLength;

        public EditTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(2, MaxNameLength).
                WithMessage($"Name can not be more than {MaxNameLength} characters");


        }

    }
}
