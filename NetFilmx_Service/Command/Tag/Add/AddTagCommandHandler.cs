using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Add
{
    public sealed class AddTagCommandHandler : ICommandHandler<AddTagCommand>
    {
        private readonly ITagRepository _repository;

        public AddTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddTagCommand command)
        {
            var validationResult = new AddTagCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsTagExist(command.Name);
            if (isExist)
            {
                return Result.Fail("Tag already exist");
            }

            var tag = new NetFilmx_Storage.Entities.Tag(command.Name);

            _repository.AddTag(tag);

            return Result.Ok(); 
        }




    }
}
