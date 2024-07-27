using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Delete
{
    public sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteCategoryCommand command)
        {
            var category = _repository.GetCategoryById(command.Id);
            if (category == null)
            {
                return Result.Fail("Category not found");
            }

            _repository.DeleteCategory(command.Id);

            return Result.Ok();
        }


    }
}
