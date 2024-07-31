using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoPurchase.Delete
{
    public sealed class DeleteVideoPurchaseCommandHandler : ICommandHandler<DeleteVideoPurchaseCommand>
    {
        private readonly IVideoPurchaseRepository _repository;

        public DeleteVideoPurchaseCommandHandler(IVideoPurchaseRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(DeleteVideoPurchaseCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                _repository.DeleteVideoPurchaseAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
