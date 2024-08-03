using MediatR;

namespace NetFilmx_Service.Command.Tag
{
    public sealed class DeleteTagCommand : IRequest<CResult>
    {

        public DeleteTagCommand(int id)
        {

            Id = id;
        }

        public int Id { get; set; }

    }
}
