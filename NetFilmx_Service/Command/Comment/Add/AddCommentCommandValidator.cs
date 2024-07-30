﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment.Add
{
    public sealed class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public static int contentMaxLength { get; } = 500;
        public AddCommentCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty").MaximumLength(contentMaxLength).WithMessage($"Content must be less than {contentMaxLength} characters");
           
        }


    }
}
