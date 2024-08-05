using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class DeleteCommentCommand : IRequest<CResult>
    {

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }

    }
}
