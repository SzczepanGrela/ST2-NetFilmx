using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetAllTagsQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetAllTagsQuery() { }
    }
}
