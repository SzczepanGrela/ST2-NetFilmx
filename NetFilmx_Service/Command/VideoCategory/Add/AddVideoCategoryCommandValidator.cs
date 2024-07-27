using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoCategory.Add
{
    public sealed class AddVideoCategoryCommandValidator : AbstractValidator<AddVideoCategoryCommand>
    {

        public AddVideoCategoryCommandValidator()
        {
            RuleFor(x => x.Video_Id).NotEmpty();
            RuleFor(x => x.Category_Id).NotEmpty();
        }


    }
}
