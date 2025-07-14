using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.UserSettings
{
    public sealed class GetUserSettingsByUserIdQuery<T> : IRequest<CResult<T>>
    {
        public GetUserSettingsByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}