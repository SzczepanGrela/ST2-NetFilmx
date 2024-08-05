using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class AddCommentCommand : IRequest<CResult>
    {

        public AddCommentCommand(int userId, int videoId, string content)
        {
            UserId = userId;
            VideoId = videoId;
            Content = content;
        }


        public int UserId { get; }

        public int VideoId { get; }

        public string Content { get; }

    }
}
