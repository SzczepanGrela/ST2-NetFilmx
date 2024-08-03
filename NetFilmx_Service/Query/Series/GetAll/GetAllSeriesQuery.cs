using MediatR;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetAllSeriesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllSeriesQuery() { }

    }
}
