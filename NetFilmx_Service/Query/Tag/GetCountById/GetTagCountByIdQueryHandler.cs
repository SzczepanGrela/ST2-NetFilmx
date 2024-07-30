using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetCountById
{
    public sealed class GetTagCountByIdQueryHandler : IQueryHandler<GetTagCountByIdQuery, QResult<int>>
    {
        private readonly ITagRepository _repository;

        public GetTagCountByIdQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public QResult<int> Handle(GetTagCountByIdQuery query)
        {
            try
            {
                int count = _repository.GetTagCountById(query.TagId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
