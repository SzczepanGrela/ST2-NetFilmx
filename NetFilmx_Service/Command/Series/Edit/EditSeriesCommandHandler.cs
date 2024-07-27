﻿using NetFilmx_Storage.Repositories;
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

        public Result Handle(EditSeriesCommand command)
        {

            var validation = new EditSeriesCommandValidator().Validate(command);

            if(!validation.IsValid)
            {
                return Result.Fail(validation);
            }

            var series = _repository.GetSeriesById(command.Id);
            if(series == null) 
            {
                return Result.Fail("Series does not exist.");
            }

            series.Name = command.Name;
            series.Price = command.Price;
            series.UpdatedAt = DateTime.Now;
            series.Description = command.Description;

            _repository.EditSeries(series);


            return Result.Ok();
        }



    }
    
}
