using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class DeleteSeriesPurchaseCommandHandler : IRequestHandler<DeleteSeriesPurchaseCommand, CResult>
    {
        private readonly ISeriesPurchaseRepository _repository;

        public DeleteSeriesPurchaseCommandHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteSeriesPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            try
            {
                await _repository.DeleteSeriesPurchaseAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }
    }
}
