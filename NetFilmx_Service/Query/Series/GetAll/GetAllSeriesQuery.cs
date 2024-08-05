using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetAllSeriesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllSeriesQuery() { }

    }
}
