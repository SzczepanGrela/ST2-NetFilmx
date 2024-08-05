using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagByNameQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetTagByNameQuery(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; }

    }
}
