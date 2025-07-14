using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.ViewHistory
{
    public record MarkVideoCompletedCommand(int UserId, int VideoId) : IRequest<CResult>;
}