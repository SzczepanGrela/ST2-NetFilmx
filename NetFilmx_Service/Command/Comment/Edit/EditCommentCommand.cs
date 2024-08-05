using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class EditCommentCommand : IRequest<CResult>
    {

        public EditCommentCommand(int id, string content)
        {
            Id = id;
            Content = content;
        }
        public int Id { get; }
        public string Content { get; }
    }

}
