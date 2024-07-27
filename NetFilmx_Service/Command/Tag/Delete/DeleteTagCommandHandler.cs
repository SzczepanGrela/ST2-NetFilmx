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

        public Result Handle(DeleteTagCommand command)
        {
           var tag = _repository.GetTagById(command.Id);

            if(tag == null)
            {
                return Result.Fail("Tag does not exist.");
            }

            _repository.DeleteTag(command.Id);

            return Result.Ok();

        }
    }
}
