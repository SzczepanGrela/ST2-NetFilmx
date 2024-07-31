using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Series.GetCountById
{
    public sealed class GetSeriesCountByIdQueryHandler : IRequestHandler<GetSeriesCountByIdQuery, QResult<int>>

    {
        private readonly ISeriesRepository _repository;

        public GetSeriesCountByIdQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetSeriesCountByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetSeriesCountByIdAsync(query.SeriesId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
