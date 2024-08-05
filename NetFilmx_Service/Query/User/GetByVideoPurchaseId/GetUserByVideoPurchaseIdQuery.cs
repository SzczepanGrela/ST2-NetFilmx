using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByVideoPurchaseIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserByVideoPurchaseIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }
        public int VideoPurchaseId { get; }

    }
}
