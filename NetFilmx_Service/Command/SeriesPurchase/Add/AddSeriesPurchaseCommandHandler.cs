using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.SeriesPurchase.Add
{
    public sealed class AddSeriesPurchaseCommandHandler : ICommandHandler<AddSeriesPurchaseCommand>
    {
        private readonly ISeriesPurchaseRepository _repository;

        public AddSeriesPurchaseCommandHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(AddSeriesPurchaseCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var seriesPurchase = new NetFilmx_Storage.Entities.SeriesPurchase(command.SeriesId, command.UserId);
            try
            {
                _repository.AddSeriesPurchase(seriesPurchase);
            }catch(Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            return CResult.Ok();


        }

    }
}
