using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetBoughtByUserId
{
    public sealed class GetBoughtSeriesByUserIdQueryHandler<TDto> : IQueryHandler<GetBoughtSeriesByUserIdQuery, QResult<List<TDto>>>
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetBoughtSeriesByUserIdQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetBoughtSeriesByUserIdQuery query)
        {
            List<TDto> seriesDto;
            try
            {
                var series = _repository.GetBoughtSeriesByUserId(query.UserId);
                seriesDto = _mapper.Map<List<TDto>>(series);
                return QResult<List<TDto>>.Ok(seriesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
