using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Like
{
    public sealed class AddLikeCommand : IRequest<CResult>
    {
        public AddLikeCommand(int userId, int videoId)
        {
            UserId = userId;
            VideoId = videoId;
        }

        public int UserId { get; }
        public int VideoId { get; }
    }
}