using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Cart
{
    public record GetCartItemCountQuery(int UserId) : IRequest<CResult<int>>;
}