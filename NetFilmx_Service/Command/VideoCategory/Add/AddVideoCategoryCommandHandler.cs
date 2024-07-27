using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoCategory.Add
{
    public sealed class AddVideoCategoryCommandHandler : ICommandHandler<AddVideoCategoryCommand>
    {

        private readonly IVideoCategoryRepository _repository;

        public AddVideoCategoryCommandHandler(IVideoCategoryRepository repository)
        {
            _repository = repository;
        }


        public Result Handle(AddVideoCategoryCommand command)
        {
            var validationResult = new AddVideoCategoryCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }


            var isExist = _repository.IsVideoCategoryExist(command.Video_Id, command.Category_Id);



            return Result.Ok();
        }




    }
}
