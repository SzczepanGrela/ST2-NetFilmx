using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoSeries.Add
{
    public sealed class AddVideoSeriesCommandHandler : ICommandHandler<AddVideoSeriesCommand>
    {

        private readonly IVideoSeriesRepository _repository;

        public AddVideoSeriesCommandHandler(IVideoSeriesRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddVideoSeriesCommand command)
        {
            var validationResult = new AddVideoSeriesCommandValidator().Validate(command);

            if(!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsVideoSeriesExist(command.Video_Id, command.Series_Id);

            if(isExist)
            {
                return Result.Fail("Connection between this Video and Series already exist");
            }

            return Result.Ok();
        }

    }
}
