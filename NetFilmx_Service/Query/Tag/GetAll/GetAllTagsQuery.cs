using MediatR;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetAllTagsQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetAllTagsQuery() { }
    }
}
