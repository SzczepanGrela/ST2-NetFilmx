using FluentValidation;

namespace NetFilmx_Service.Command.User
{
    public sealed class NewPasswordCommandValidator : AbstractValidator<NewPasswordCommand>
    {


        public static int maxPasswordLength { get; } = AddUserCommandValidator.maxPasswordLength;

        public static int minPasswordLength { get; } = AddUserCommandValidator.minPasswordLength;


        public NewPasswordCommandValidator()
        {

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MaximumLength(maxPasswordLength).WithMessage($"Password must be less than {maxPasswordLength} characters").
                MinimumLength(minPasswordLength).WithMessage($"Password must be more than {minPasswordLength} characters");
        }
    }
}
