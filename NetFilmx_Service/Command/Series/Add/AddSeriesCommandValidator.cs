﻿using FluentValidation;

namespace NetFilmx_Service.Command.Series
{
    internal class AddSeriesCommandValidator : AbstractValidator<AddSeriesCommand>
    {

        public static int maxDescriptionLength { get; } = 2000;

        public AddSeriesCommandValidator()
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
