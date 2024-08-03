using MediatR;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.User
{
    public sealed class IsUsernameAvailableQueryHandler : IRequestHandler<IsUsernameAvailableQuery, QResult<bool>>
    {
        private readonly IUserRepository _repository;

        public IsUsernameAvailableQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<bool>> Handle(IsUsernameAvailableQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                return QResult<bool>.Fail("Query is null");
            }

            var isEdit = query.Id.HasValue;
            try
            {

                if (isEdit)
                {
                    var isUsernameTaken = await _repository.IsUsernameAvailableForUserAsync(query.Username, query.Id.Value);
                    return QResult<bool>.Ok(!isUsernameTaken);
                }
                else
                {
                    var isUsernameTaken = await _repository.IsUsernameTakenAsync(query.Username);
                    return QResult<bool>.Ok(!isUsernameTaken);
                }



            }
            catch (Exception ex)
            {
                return QResult<bool>.Fail(ex.Message);
            }
        }

    }
}
