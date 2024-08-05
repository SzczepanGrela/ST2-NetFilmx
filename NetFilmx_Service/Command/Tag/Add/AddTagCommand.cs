using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class AddTagCommand : IRequest<CResult>
    {

        public AddTagCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
