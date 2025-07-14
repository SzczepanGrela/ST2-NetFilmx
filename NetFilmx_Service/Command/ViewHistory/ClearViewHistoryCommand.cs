using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.ViewHistory
{
    public record ClearViewHistoryCommand(int UserId) : IRequest<CResult>;
}