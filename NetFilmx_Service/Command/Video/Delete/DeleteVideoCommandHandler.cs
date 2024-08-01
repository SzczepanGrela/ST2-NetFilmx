using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, CResult>
    {

        private readonly IVideoRepository _repository;

        public DeleteVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public async Task<CResult> Handle(DeleteVideoCommand command, CancellationToken cancellationToken)
        {
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                await _repository.DeleteVideoAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
