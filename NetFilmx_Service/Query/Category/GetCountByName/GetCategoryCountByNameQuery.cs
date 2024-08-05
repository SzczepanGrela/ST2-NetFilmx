using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryCountByNameQuery : IRequest<QResult<int>>
    {
        public GetCategoryCountByNameQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
        public string CategoryName { get; }

    }
}
