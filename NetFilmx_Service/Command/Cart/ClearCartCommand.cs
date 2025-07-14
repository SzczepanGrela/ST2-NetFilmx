using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Cart
{
    public record ClearCartCommand(int UserId) : IRequest<CResult>;
}