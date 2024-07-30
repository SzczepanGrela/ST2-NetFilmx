using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Category.GetCountByName
{
    public sealed class GetCategoryCountByNameQueryHandler : IQueryHandler<GetCategoryCountByNameQuery, QResult<int>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryCountByNameQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public QResult<int> Handle(GetCategoryCountByNameQuery query)
        {
            try
            {
                int count = _repository.GetCategoryCountByName(query.CategoryName);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
