using FluentValidation;

namespace NetFilmx_Service.Command.User
{
    public sealed class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public static int maxUsernameLength { get; } = AddUserCommandValidator.maxUsernameLength;

        public static int minUsernameLength { get; } = AddUserCommandValidator.minUsernameLength;

        public static int maxEmailLength { get; } = AddUserCommandValidator.maxEmailLength;

        public static int minEmailLength { get; } = AddUserCommandValidator.minEmailLength;



        public EditUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").MaximumLength(maxUsernameLength).
                WithMessage($"Username must be less than {maxUsernameLength} characters").MinimumLength(minUsernameLength).WithMessage($"Username must be more than {minUsernameLength} characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").MaximumLength(maxEmailLength).WithMessage($"Email must be less than {maxEmailLength} characters").
                MinimumLength(minEmailLength).WithMessage($"Email must be more than {minEmailLength} characters");


        }
    }
}
