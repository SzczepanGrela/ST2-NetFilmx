using FluentValidation;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class AddTagCommandValidator : AbstractValidator<AddTagCommand>
    {

        public static int MaxNameLength { get; } = 100;

        public AddTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(MaxNameLength).
                WithMessage($"Name must be less that {MaxNameLength} characters");


        }


    }
}
