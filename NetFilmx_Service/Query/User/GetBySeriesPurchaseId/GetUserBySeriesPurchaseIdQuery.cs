using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserBySeriesPurchaseIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetUserBySeriesPurchaseIdQuery(int seriesPurchaseId)
        {
            SeriesPurchaseId = seriesPurchaseId;
        }
        public int SeriesPurchaseId { get; }

    }
}
