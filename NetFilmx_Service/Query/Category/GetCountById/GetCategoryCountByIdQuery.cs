using MediatR;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryCountByIdQuery : IRequest<QResult<int>>
    {
        public GetCategoryCountByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; }
    }
}
