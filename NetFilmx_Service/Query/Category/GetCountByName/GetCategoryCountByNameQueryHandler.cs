using NetFilmx_Storage.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountByName
{
    public sealed class GetCategoryCountByNameQueryHandler : IQueryHandler<GetCategoryCountByNameQuery, int>
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
                int count = await _repository.GetCategoryCountByNameAsync(query.CategoryName);

                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
