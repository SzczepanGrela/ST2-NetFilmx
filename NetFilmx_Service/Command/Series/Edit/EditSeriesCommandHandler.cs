using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Edit
{
    public sealed class EditSeriesCommandHandler : ICommandHandler<EditSeriesCommand>
    {
        private readonly ISeriesRepository _repository;

        public EditSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(EditSeriesCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new EditSeriesCommandValidator().Validate(command);

            if (!validation.IsValid)
            {
                return CResult.Fail(validation);
            }
            try
            {
                var series = _repository.GetSeriesById(command.Id);         

                series.Name = command.Name;
                series.Price = command.Price;
                series.UpdatedAt = DateTime.Now;
                series.Description = command.Description;

                _repository.UpdateSeries(series);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
 
        }

    }

}
