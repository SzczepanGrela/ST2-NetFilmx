﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Series
{
    public sealed class EditSeriesCommandHandler : IRequestHandler<EditSeriesCommand, CResult>
    {
        private readonly ISeriesRepository _repository;

        public EditSeriesCommandHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(EditSeriesCommand command, CancellationToken cancellationToken)
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
                var series = await _repository.GetSeriesByIdAsync(command.Id);

                //var series = task.Result;

                series.Name = command.Name;
                series.Price = command.Price;
                
                series.Description = command.Description;

                series.UpdatedAt = DateTime.Now;

                await _repository.UpdateSeriesAsync(series);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
 
        }

    }

}
