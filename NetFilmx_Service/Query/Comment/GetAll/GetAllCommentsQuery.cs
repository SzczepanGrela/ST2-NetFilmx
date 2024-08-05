using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetAllCommentsQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllCommentsQuery() { }
    }
}
