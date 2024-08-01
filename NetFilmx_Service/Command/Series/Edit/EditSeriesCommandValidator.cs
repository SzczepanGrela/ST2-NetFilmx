using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series
{
    internal class EditSeriesCommandValidator : AbstractValidator<EditSeriesCommand>
    {
        public static int maxDescriptionLength { get; } = AddSeriesCommandValidator.maxDescriptionLength; 
      
        public EditSeriesCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Description).MaximumLength(maxDescriptionLength).WithMessage($"Description can not be more than {maxDescriptionLength} characters");


            RuleFor(x => x.Price)
           .NotEmpty()
           .WithMessage("Price is required")
           .GreaterThanOrEqualTo(0)
           .WithMessage("Price cannot be negative");
        }
    }
}
