using MediatR;

namespace NetFilmx_Service.Query.Comment
{
    public sealed class GetAllCommentsQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllCommentsQuery() { }
    }
}
