using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment.Delete
{
    internal class DeletecommentCommandHandler
    {

        private readonly ICommentRepository _repository;

        public DeletecommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }


        public Result Handle(DeleteCommentCommand command)
        {
            var comment = _repository.GetCommentById(command.Id);

            if(comment == null)
            {
                return Result.Fail("Comment does not exist.");
            }

            _repository.DeleteComment(command.Id);

            return Result.Ok();

        }


    }
}
