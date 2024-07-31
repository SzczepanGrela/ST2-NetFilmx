﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Video.Add
{
    public sealed class AddVideoCommandHandler : ICommandHandler<AddVideoCommand>
    {
        private readonly IVideoRepository _repository;

        public AddVideoCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddVideoCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validation = new AddVideoCommandValidator().Validate(command);
            if (!validation.IsValid)
            {
                return CResult.Fail(validation);
            }


            var video = new NetFilmx_Storage.Entities.Video(command.Title, command.Description, command.Price, command.Video_url, command.Thumbnail_url);

            try
            {
                _repository.AddVideoAsync(video);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            


        }

    }
}
