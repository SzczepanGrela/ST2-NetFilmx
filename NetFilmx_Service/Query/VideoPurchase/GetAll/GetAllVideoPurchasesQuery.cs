using MediatR;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetAllVideoPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetAllVideoPurchasesQuery() { }
    }
}
