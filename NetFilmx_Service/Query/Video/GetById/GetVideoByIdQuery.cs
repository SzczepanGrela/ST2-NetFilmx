using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByIdQuery<TDto> : IRequest<QResult<TDto>>
    {

        public GetVideoByIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }


    }
}
