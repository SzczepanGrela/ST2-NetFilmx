using MediatR;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetAllSeriesPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllSeriesPurchasesQuery() { }

    }
}
