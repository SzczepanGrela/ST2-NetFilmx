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


        public CResult Handle(DeleteCommentCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }        
           
            try
            {
                _repository.DeleteCommentAsync(command.Id);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            

        }


    }
}
