using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Add
{
    public sealed class AddTagCommandHandler : ICommandHandler<AddTagCommand>
    {
        private readonly ITagRepository _repository;

        public AddTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(AddTagCommand command)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var validationResult = new AddTagCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return CResult.Fail(validationResult);
            }

            var tag = new NetFilmx_Storage.Entities.Tag(command.Name);

            try
            {
                _repository.AddTagAsync(tag);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }




    }
}
