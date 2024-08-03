using MediatR;

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
