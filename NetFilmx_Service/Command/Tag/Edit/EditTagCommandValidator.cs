using FluentValidation;

namespace NetFilmx_Service.Command.Tag
{
    internal class EditTagCommandValidator : AbstractValidator<EditTagCommand>
    {

        public int MaxNameLength { get; } = AddTagCommandValidator.MaxNameLength;

        public EditTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(2, MaxNameLength).
                WithMessage($"Name be between 2 and {MaxNameLength} characters");


        }

    }
}
