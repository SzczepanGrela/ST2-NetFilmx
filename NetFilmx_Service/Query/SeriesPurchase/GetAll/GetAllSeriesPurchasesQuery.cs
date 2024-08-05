using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetAllSeriesPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllSeriesPurchasesQuery() { }

    }
}
