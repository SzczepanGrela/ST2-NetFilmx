using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment.Edit
{
    public sealed class EditCommentCommandHandler : ICommandHandler<EditCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public EditCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }


        public CResult Handle(EditCommentCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            var commandValidation = new EditCommentCommandValidator().Validate(command);

            if (!commandValidation.IsValid)
            {
                return CResult.Fail(commandValidation);
            }

            try
            {
                var comment = _repository.GetCommentById(command.Id);

                comment.Content = command.Content;
                comment.UpdatedAt = DateTime.Now;

                _repository.UpdateComment(comment);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }
    }
}
