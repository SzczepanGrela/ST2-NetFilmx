using NetFilmx_Storage.Entities;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;
namespace NetFilmx_Service.Command.Series.Add
{
    public sealed class AddSeriesCommandHandler  : ICommandHandler<AddSeriesCommand>
    {

        private readonly ISeriesRepository _repository;

        public AddSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddSeriesCommand command)
        {
            var validationResult = new AddSeriesCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsSeriesExist(command.Name);

            if (isExist)
            {
                return Result.Fail("Series already exist");
            }

            var series = new NetFilmx_Storage.Entities.Series(command.Name, command.Price, command.Description, DateTime.Now, DateTime.Now);

            _repository.AddSeries(series);

            return Result.Ok();
        }


    }
}
