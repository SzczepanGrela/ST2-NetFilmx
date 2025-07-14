using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.ViewHistory
{
    public record GetViewHistoryByUserIdQuery<T>(int UserId) : IRequest<CResult<List<T>>>;
}