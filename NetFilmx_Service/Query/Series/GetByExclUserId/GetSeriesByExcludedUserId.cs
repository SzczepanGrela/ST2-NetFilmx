using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByExcludedUserIdQuery<TDto> : IRequest<QResult<List<TDto>>>
    {


        public GetSeriesByExcludedUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }

    }
}
