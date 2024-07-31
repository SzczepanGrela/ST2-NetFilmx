﻿using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Category.Delete
{
    public sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteCategoryAsync(command.Id);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            
        }


    }
}
