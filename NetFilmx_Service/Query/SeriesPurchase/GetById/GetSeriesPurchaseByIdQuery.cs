using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchaseByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetSeriesPurchaseByIdQuery(int seriesPurchaseId)
        {
            SeriesPurchaseId = seriesPurchaseId;
        }
        public int SeriesPurchaseId { get; }


    }
}
