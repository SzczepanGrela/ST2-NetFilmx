using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountById
{
    public sealed class GetCategoryCountByIdQueryHandler : IQueryHandler<GetCategoryCountByIdQuery, QResult<int>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryCountByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public QResult<int> Handle(GetCategoryCountByIdQuery query)
        {
            try
            {
                int count = _repository.GetCategoryCountById(query.CategoryId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
