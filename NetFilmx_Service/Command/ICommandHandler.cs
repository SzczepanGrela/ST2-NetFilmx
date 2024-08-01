/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : IRequest<CResult>
    {
      

        Task<CResult> Handle(TCommand command, CancellationToken cancellationToken);

    }

}
*/