using NetFilmx_Storage.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountById
{
    public sealed class GetCategoryCountByIdQueryHandler : IQueryHandler<GetCategoryCountByIdQuery, int>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryCountByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetCategoryCountByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetCategoryCountByIdAsync(query.CategoryId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
