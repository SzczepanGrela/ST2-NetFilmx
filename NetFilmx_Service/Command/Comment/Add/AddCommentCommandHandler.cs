using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, CResult>
    {
        private readonly ICommentRepository _repository;

        public AddCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(AddCommentCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            var commandValidation = new AddCommentCommandValidator().Validate(command);

            if (!commandValidation.IsValid)
            {
                return CResult.Fail(commandValidation);
            }

            var comment = new NetFilmx_Storage.Entities.Comment(command.VideoId, command.UserId, command.Content);

            try
            {
                await _repository.AddCommentAsync(comment);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }
    }
}
