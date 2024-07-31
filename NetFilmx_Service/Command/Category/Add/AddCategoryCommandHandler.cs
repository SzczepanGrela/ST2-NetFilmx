using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Repositories;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Command.Category
{
    public sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {

        private readonly ICategoryRepository _repository;

        public AddCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new AddCategoryCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

        
            var category = new NetFilmx_Storage.Entities.Category(command.Name, command.Description);

            try
            {
                await _repository.AddCategoryAsync(category);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }

    }
}
