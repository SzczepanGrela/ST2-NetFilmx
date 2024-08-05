using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByCategoryIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetVideosByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }


    }
}
