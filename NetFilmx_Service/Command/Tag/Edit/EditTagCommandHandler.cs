using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class EditTagCommandHandler : IRequestHandler<EditTagCommand, CResult>
    {
        private readonly ITagRepository _repository;

        public EditTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(EditTagCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }


            var validationResult = new EditTagCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            try
            {
                var tag = await _repository.GetTagByIdAsync(command.Id);
                //var tag = task.Result;
                tag.Name = command.Name;

                await _repository.UpdateTagAsync(tag);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }
    }
}
