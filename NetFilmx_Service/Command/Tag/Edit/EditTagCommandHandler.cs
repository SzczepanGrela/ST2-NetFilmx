using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Edit
{
    public sealed class EditTagCommandHandler
    {
        private readonly ITagRepository _repository;

        public EditTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(EditTagCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
            

            var validationResult = new EditTagCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            try
            {
                var tag = await _repository.GetTagByIdAsync(command.Id);
                //var tag = task.Result;
                tag.Name = command.Name;

                await _repository.UpdateTagAsync(tag);

                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }
    }
}
