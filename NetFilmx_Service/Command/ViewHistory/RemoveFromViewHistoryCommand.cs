using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.ViewHistory
{
    public record RemoveFromViewHistoryCommand(int ViewHistoryId) : IRequest<CResult>;
}