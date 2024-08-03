using FluentValidation;

namespace NetFilmx_Service.Command.Category
{
    internal class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {

        public int maxNameLength { get; } = AddCategoryCommandValidator.maxNameLength;
        public int maxDescriptionLength { get; } = AddCategoryCommandValidator.maxDescriptionLength;

        public EditCategoryCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(maxNameLength).WithMessage($"Name can not be more than {maxNameLength} characters");
            RuleFor(x => x.Description).MaximumLength(maxDescriptionLength).WithMessage($"Description can not be more than {maxDescriptionLength} characters");
        }

    }
}
