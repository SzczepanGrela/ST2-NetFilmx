using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Service.Command.User.RegisterUser;

namespace NetFilmx_Service.Command.User.EditUser
{
    public sealed class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public static int maxUsernameLength { get; } = RegisterUserCommandValidator.maxUsernameLength;
        public static int maxEmailLength { get; } = RegisterUserCommandValidator.maxEmailLength;
        public static int maxPasswordLength { get; } = RegisterUserCommandValidator.maxPasswordLength;

        public EditUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").MaximumLength(maxUsernameLength).WithMessage($"Username must be less than {maxUsernameLength} characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").MaximumLength(maxEmailLength).WithMessage($"Email must be less than {maxEmailLength} characters");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MaximumLength(maxPasswordLength).WithMessage($"Password must be less than {maxPasswordLength} characters");
        }
    }
}
