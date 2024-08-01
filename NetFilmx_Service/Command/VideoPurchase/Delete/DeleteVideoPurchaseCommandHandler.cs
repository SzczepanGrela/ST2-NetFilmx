using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public sealed class DeleteVideoPurchaseCommandHandler : IRequestHandler<DeleteVideoPurchaseCommand, CResult>
    {
        private readonly IVideoPurchaseRepository _repository;

        public DeleteVideoPurchaseCommandHandler(IVideoPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteVideoPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteVideoPurchaseAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }

    }
}
