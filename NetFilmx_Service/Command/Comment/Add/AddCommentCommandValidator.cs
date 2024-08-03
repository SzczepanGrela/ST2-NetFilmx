using FluentValidation;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public static int contentMaxLength { get; } = 500;
        public AddCommentCommandValidator()
        {

            RuleFor(x => x.VideoId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty").MaximumLength(contentMaxLength).WithMessage($"Content must be less than {contentMaxLength} characters");

        }


    }
}
