using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByNameQuery : IRequest<QResult<int>>
    {
        public GetTagCountByNameQuery(string tagName)
        {
            TagName = tagName;
        }
        public string TagName { get; }

    }
}
