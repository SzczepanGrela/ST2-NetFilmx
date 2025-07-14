using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Cart
{
    public record AddVideoToCartCommand(int UserId, int VideoId) : IRequest<CResult>;
}