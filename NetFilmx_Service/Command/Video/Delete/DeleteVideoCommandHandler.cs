using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Delete
{
    public sealed class DeleteVideoCommandHandler : ICommandHandler<DeleteVideoCommand>
    {

        private readonly IVideoRepository _repository;

        public DeleteVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }


        public CResult Handle(DeleteVideoCommand command)
        {
            if(command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {
                _repository.DeleteVideo(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
