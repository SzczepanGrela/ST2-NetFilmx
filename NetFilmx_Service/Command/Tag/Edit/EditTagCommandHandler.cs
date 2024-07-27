using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Edit
{
    public sealed class EditTagCommandHandler
    {
        private readonly ITagRepository _repository;

        public EditTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(EditTagCommand command)
        {
            var validationResult = new EditTagCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var tag = _repository.GetTagById(command.Id);

            if (tag == null)
            {
                return Result.Fail("Tag not found");
            }

            tag.Name = command.Name;           

            _repository.EditTag(tag);

            return Result.Ok();
        }
    }
}
