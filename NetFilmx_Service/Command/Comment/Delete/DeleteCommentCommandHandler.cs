using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, CResult>
    {

        private readonly ICommentRepository _repository;

        public DeleteCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }        
           
            try
            {
                await _repository.DeleteCommentAsync(command.Id);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            

        }


    }
}
