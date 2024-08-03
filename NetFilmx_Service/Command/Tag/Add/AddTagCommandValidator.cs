using FluentValidation;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class AddTagCommandValidator : AbstractValidator<AddTagCommand>
    {

        public static int MaxNameLength { get; } = 100;

        public AddTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").Length(2, MaxNameLength).
                WithMessage($"Name must be between 2 and {MaxNameLength} characters");


        }


    }
}
