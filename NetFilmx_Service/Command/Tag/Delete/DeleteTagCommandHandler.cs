using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Tag.Delete
{
    internal class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {


        private readonly ITagRepository _repository;

        public DeleteTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public CResult Handle(DeleteTagCommand command)
        {

            if (command == null)
            {
                return CResult.Fail("Command is null");
            }
          
            try
            {
                _repository.DeleteTag(command.Id);
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            return CResult.Ok();

        }
    }
}
