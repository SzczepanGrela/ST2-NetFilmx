using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Repositories;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Command.Category.Add
{
    public sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {

        private readonly ICategoryRepository _repository;

        public AddCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(AddCategoryCommand command)
        {
            var validationResult = new AddCategoryCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            var isExist = _repository.IsCategoryExist(command.Name);
            if (isExist)
            {
                return CResult.Fail("Category already exist");
            }

            var category = new NetFilmx_Storage.Entities.Category(command.Name, command.Description);

            _repository.AddCategory(category);

            return CResult.Ok(); 


        }



    }
}
