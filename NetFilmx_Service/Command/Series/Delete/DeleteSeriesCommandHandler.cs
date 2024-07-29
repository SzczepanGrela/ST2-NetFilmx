using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Series.Delete
{
    public sealed class DeleteSeriesCommandHandler
    {
        private readonly ISeriesRepository _repository;


        public DeleteSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }


        public CResult Handle(DeleteSeriesCommand command)
        {
            var move = _repository.GetSeriesById(command.Id);

            if (move == null)
            {
                return CResult.Fail("Series does not exist.");
            }

            _repository.DeleteSeries(command.Id);

            return CResult.Ok();
        }



    }
}
