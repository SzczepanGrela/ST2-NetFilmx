using NetFilmx_Service.Command.Category.Add;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Edit
{
    public sealed class EditCategoryCommandHandler
    {

        private readonly ICategoryRepository _repository;

        public EditCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(EditCategoryCommand command)
        {
            var validationResult = new EditCategoryCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var category = _repository.GetCategoryById(command.Id);

            if (category == null)
            {
                return Result.Fail("Category not found");
            }

            category.Name = command.Name;
            category.Description = command.Description;

            _repository.EditCategory(category);

            return Result.Ok();
        }

    }
}
