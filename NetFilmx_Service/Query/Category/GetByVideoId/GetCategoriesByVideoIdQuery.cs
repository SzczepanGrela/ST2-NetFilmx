using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoriesByVideoIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetCategoriesByVideoIdQuery(int videoId)
        {
            VideoId = videoId;
        }
        public int VideoId { get; }

    }
}
