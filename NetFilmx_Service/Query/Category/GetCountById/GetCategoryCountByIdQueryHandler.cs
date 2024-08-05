using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryCountByIdQueryHandler : IRequestHandler<GetCategoryCountByIdQuery, QResult<int>>

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
                int count = await _repository.GetVideoCountByCategoryIdAsync(query.CategoryId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
