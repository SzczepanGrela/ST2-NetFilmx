using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class AddTagCommandValidator : AbstractValidator<AddTagCommand>
    {

        public static int MaxNameLength { get; } = 50;

        public AddTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(2, MaxNameLength).
                WithMessage($"Name can not be more than {MaxNameLength} characters");
            
        
        }   


    }
}
