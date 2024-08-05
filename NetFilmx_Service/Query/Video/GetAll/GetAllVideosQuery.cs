using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetAllVideosQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetAllVideosQuery() { }
    }
}
