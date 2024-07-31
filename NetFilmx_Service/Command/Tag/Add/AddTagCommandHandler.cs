using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class AddTagCommandHandler : ICommandHandler<AddTagCommand>
    {
        private readonly ITagRepository _repository;

        public AddTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(AddTagCommand command, CancellationToken cancellationToken)
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
                await _repository.AddTagAsync(tag);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            
        }




    }
}
