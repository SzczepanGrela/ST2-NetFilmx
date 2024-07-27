using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoTag.Add
{
    public sealed class AddVideoTagCommandHandler : ICommandHandler<AddVideoTagCommand>
    {

        private readonly IVideoTagRepository _repository;

       
        public AddVideoTagCommandHandler(IVideoTagRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddVideoTagCommand command)
        {

            var validationResult = new AddVideoTagCommandValidator().Validate(command);

            if(!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsVideoTagExist(command.Video_Id, command.Tag_Id);

            if(isExist)
            {
                return Result.Fail("Connection between this Video and Tag already exist");
            }

            return Result.Ok();


        }

    }
}
