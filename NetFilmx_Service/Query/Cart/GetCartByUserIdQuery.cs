using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Cart
{
    public record GetCartByUserIdQuery<T>(int UserId) : IRequest<CResult<T>>;
}