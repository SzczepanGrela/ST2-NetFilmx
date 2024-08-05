using MediatR;
using NetFilmx_Service.Result;

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
