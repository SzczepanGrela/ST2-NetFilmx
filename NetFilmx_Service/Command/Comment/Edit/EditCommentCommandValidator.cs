using FluentValidation;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public int contentMaxLength { get; } = AddCommentCommandValidator.contentMaxLength;

        public EditCommentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty").MaximumLength(contentMaxLength).WithMessage($"Content must be less than {contentMaxLength} characters");
        }
    }
}
