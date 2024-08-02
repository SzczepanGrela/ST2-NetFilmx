using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.User
{
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public static int maxUsernameLength { get; } = 50;

        public static int minUsernameLength { get; } = 5;

        public static int maxEmailLength { get; } = 50;

        public static int minEmailLength { get; } = 5;

        public static int maxPasswordLength { get; } = 50;

        public static int minPasswordLength { get; } = 8;

        public AddUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").MaximumLength(maxUsernameLength).
                WithMessage($"Username must be less than {maxUsernameLength} characters").MinimumLength(minUsernameLength).WithMessage($"Username must be more than {minUsernameLength} characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").MaximumLength(maxEmailLength).WithMessage($"Email must be less than {maxEmailLength} characters").
                MinimumLength(minEmailLength).WithMessage($"Email must be more than {minEmailLength} characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MaximumLength(maxPasswordLength).WithMessage($"Password must be less than {maxPasswordLength} characters").
                MinimumLength(minPasswordLength).WithMessage($"Password must be more than {minPasswordLength} characters");
        }

    }
}
