using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User.RegisterUser
{
    public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public static int maxUsernameLength { get; } = 50;
        public static int maxEmailLength { get; } = 50;
        public static int maxPasswordLength { get; } = 50;

        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").MaximumLength(maxUsernameLength).WithMessage($"Username must be less than {maxUsernameLength} characters");    
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").MaximumLength(maxEmailLength).WithMessage($"Email must be less than {maxEmailLength} characters");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MaximumLength(maxPasswordLength).WithMessage($"Password must be less than {maxPasswordLength} characters");
        }

    }
}
