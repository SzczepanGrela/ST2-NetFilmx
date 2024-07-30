using NetFilmx_Storage.Entities;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NetFilmx_Service.Command.Series.Add
{
    public sealed class AddSeriesCommandHandler : ICommandHandler<AddSeriesCommand>
    {

        private readonly ISeriesRepository _repository;

        public AddSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(AddSeriesCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            var validationResult = new AddSeriesCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            var series = new NetFilmx_Storage.Entities.Series(command.Name, command.Price, command.Description);
            try
            {
                _repository.AddSeries(series);
                return CResult.Ok();

            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }

    }
}
