using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByTagIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosByTagIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
