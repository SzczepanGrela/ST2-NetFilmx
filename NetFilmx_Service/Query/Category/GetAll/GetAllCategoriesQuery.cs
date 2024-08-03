using MediatR;
using NetFilmx_Service.Dtos.Category;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetAllCategoriesQuery<TDto> : IRequest<QResult<List<TDto>>>
        where TDto : ICategoryDto
    {
        public GetAllCategoriesQuery() { }
    }

}
