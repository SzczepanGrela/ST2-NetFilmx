using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Cart
{
    public record RemoveCartItemCommand(int CartItemId) : IRequest<CResult>;
}