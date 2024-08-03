using MediatR;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryByNameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
        public string Name { get; }


    }

}
