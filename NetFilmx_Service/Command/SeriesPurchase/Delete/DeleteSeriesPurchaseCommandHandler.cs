using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.SeriesPurchase.Delete
{
    public sealed class DeleteSeriesPurchaseCommandHandler : ICommandHandler<DeleteSeriesPurchaseCommand>
    {
        private readonly ISeriesPurchaseRepository _repository;

        public DeleteSeriesPurchaseCommandHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(DeleteSeriesPurchaseCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            try
            {
                _repository.DeleteSeriesPurchase(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

        }
    }
}
