using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchaseByIdQuery<TDto> : IRequest<QResult<TDto>>
    {

        public GetVideoPurchaseByIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }
        public int VideoPurchaseId { get; }

    }
}
