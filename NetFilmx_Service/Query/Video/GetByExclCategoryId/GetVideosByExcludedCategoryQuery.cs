using MediatR;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedCategoryQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetVideosByExcludedCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }

    }
}
