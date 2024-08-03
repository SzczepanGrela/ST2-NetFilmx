using FluentValidation;

namespace NetFilmx_Service.Command.Tag
{
    internal class EditTagCommandValidator : AbstractValidator<EditTagCommand>
    {

        public int MaxNameLength { get; } = AddTagCommandValidator.MaxNameLength;

        public EditTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(MaxNameLength).
               WithMessage($"Name must be less that {MaxNameLength} characters");



        }

    }
}
