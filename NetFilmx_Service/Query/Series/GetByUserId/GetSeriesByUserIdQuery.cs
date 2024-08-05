using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {
        public GetSeriesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
    }
}
