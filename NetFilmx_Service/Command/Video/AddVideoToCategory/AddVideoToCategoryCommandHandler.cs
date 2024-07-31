﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetFilmx_Service.Command.Video.AddVideoToCategory
{
    public sealed class AddVideoToCategoryCommandHandler : ICommandHandler<AddVideoToCategoryCommand>
    {
        private readonly IVideoRepository _repository;

        public AddVideoToCategoryCommandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddVideoToCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            try
            {            
                await _repository.AddVideoToCategoryAsync(command.CategoryId, command.VideoId);
                return CResult.Ok();
            }
            catch
            (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
        }
    }
}
