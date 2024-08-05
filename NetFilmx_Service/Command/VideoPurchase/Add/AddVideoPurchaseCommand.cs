using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public sealed class AddVideoPurchaseCommand : IRequest<CResult>
    {

        public AddVideoPurchaseCommand(int userid, int videoid)
        {
            UserId = userid;
            VideoId = videoid;
        }

        public int UserId { get; }

        public int VideoId { get; }




    }
}
