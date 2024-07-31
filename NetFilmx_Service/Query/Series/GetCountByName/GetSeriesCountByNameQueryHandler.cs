using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesCountByNameQueryHandler : IRequestHandler<GetSeriesCountByNameQuery, QResult<int>>
    {
        private readonly ISeriesRepository _repository;

        public GetSeriesCountByNameQueryHandler(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetSeriesCountByNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetSeriesCountByNameAsync(query.SeriesName);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
