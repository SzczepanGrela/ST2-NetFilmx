using MediatR;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class EditTagCommand : IRequest<CResult>
    {

        public EditTagCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }


    }
}
