using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetFilmx_Service.Command.Category
{
    public  class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public static int maxNameLength { get; } = 50;
        public static int maxDescriptionLength { get; } = 200;

        public AddCategoryCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(maxNameLength).WithMessage($"Name can not be more than {maxNameLength} characters");
            RuleFor(x => x.Description).MaximumLength(maxDescriptionLength).WithMessage($"Description can not be more than {maxDescriptionLength} characters");
        }


    }
}
