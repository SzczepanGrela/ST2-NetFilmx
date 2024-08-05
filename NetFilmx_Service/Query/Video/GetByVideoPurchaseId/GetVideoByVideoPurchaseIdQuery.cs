using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByVideoPurchaseIdQuery<TDto> : IRequest<QResult<TDto>>
    {

        public GetVideoByVideoPurchaseIdQuery(int videoPurchaseId)
        {
            VideoPurchaseId = videoPurchaseId;
        }

        public int VideoPurchaseId { get; }

    }
}
