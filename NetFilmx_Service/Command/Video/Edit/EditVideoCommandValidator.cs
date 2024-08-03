using FluentValidation;

namespace NetFilmx_Service.Command.Video
{
    public sealed class EditVideoCommandValidator : AbstractValidator<EditVideoCommand>
    {
        public static int titleMaxLength { get; } = AddVideoCommandValidator.titleMaxLength;

        public static int maxDescriptionLength { get; } = AddVideoCommandValidator.maxDescriptionLength;
        public EditVideoCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3).WithMessage($"Title must be more than 3 characters").MaximumLength(titleMaxLength).WithMessage($"Title must be less than {titleMaxLength} characters");
            RuleFor(x => x.Description).MaximumLength(maxDescriptionLength).WithMessage($"Description can not be more than {maxDescriptionLength} characters");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty").GreaterThanOrEqualTo(0).WithMessage("Price cannot be lower than 0");
            RuleFor(x => x.Video_url).NotEmpty().WithMessage("Url cannot be empty").MinimumLength(3).WithMessage("Url must be at least 3 chaacters");

        }
    }
}
