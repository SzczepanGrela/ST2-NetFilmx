using MediatR;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetAllUsersQuery<TDto> : IRequest<QResult<List<TDto>>>
    {

        public GetAllUsersQuery() { }
    }
}
