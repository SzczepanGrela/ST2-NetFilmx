using FluentValidation;
using NetFilmx_Service.Command.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public int contentMaxLength { get; } = AddCommentCommandValidator.contentMaxLength;

        public EditCommentCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty").MaximumLength(contentMaxLength).WithMessage($"Content must be less than {contentMaxLength} characters");
        }
    }
}
