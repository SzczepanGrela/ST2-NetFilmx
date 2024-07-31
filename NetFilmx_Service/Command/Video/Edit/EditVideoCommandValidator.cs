using FluentValidation;
using NetFilmx_Service.Command.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video
{
    public sealed class EditVideoCommandValidator : AbstractValidator<EditVideoCommand>
    {
        public static int titleMaxLength { get; } = AddVideoCommandValidator.titleMaxLength;
        public EditVideoCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3).WithMessage($"Title must be more than 3 characters").MaximumLength(titleMaxLength).WithMessage($"Title must be less than {titleMaxLength} characters");
            RuleFor(x => x.Description).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty").GreaterThanOrEqualTo(0).WithMessage("Price cannot be lower than 0");
            RuleFor(x => x.Video_url).NotEmpty().WithMessage("Url cannot be empty").MinimumLength(3).WithMessage("Url must be at least 3 chaacters");

        }
    }
}
