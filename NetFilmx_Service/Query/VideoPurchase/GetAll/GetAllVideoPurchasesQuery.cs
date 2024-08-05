using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetAllVideoPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllVideoPurchasesQuery() { }
    }
}
