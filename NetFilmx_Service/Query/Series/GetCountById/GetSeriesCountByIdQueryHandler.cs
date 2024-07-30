using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetCountById
{
    public sealed class GetSeriesCountByIdQueryHandler : IQueryHandler<GetSeriesCountByIdQuery, QResult<int>>
    {
        private readonly ISeriesRepository _repository;

        public GetSeriesCountByIdQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public QResult<int> Handle(GetSeriesCountByIdQuery query)
        {
            try
            {
                int count = _repository.GetSeriesCountById(query.SeriesId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
