using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.ViewHistory
{
    public record RecordViewingProgressCommand(int UserId, int VideoId, int ProgressSeconds, int DurationSeconds) : IRequest<CResult>;
}