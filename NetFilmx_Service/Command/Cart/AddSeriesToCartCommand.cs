using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Cart
{
    public record AddSeriesToCartCommand(int UserId, int SeriesId) : IRequest<CResult>;
}