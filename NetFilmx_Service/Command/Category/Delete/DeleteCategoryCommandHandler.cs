using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Category
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CResult>
    {

        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteCategoryAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }


    }
}
