using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Service.Command.User;

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
