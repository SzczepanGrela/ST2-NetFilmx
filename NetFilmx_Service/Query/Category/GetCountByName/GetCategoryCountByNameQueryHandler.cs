using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryCountByNameQueryHandler : IRequestHandler<GetCategoryCountByNameQuery, QResult<int>>

    {
        private readonly ICategoryRepository _repository;

        public GetCategoryCountByNameQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetCategoryCountByNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetVideoCountByCategoryNameAsync(query.CategoryName);

                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
