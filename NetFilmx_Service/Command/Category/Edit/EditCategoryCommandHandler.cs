using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Category
{
    public sealed class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, CResult>
    {

        private readonly ICategoryRepository _repository;

        public EditCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            var validationResult = new EditCategoryCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            try
            {
                var category = await _repository.GetCategoryByIdAsync(command.Id);
                category.Name = command.Name;
                category.Description = command.Description;


                await _repository.UpdateCategoryAsync(category);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }

    }
}
