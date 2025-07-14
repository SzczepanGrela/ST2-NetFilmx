using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.ViewHistory
{
    public record GetContinueWatchingQuery<T>(int UserId) : IRequest<CResult<List<T>>>;
}