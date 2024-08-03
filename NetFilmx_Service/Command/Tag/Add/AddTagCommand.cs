using MediatR;

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
