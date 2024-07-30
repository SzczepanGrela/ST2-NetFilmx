using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetByName
{
    public sealed class GetSeriesByNameQueryHandler<TDto> : IQueryHandler<GetSeriesByNameQuery, QResult<TDto>>
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByNameQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetSeriesByNameQuery query)
        {
            var series = _repository.GetSeriesByName(query.SeriesName);
            if (series == null)
            {
                return QResult<TDto>.Fail("Series not found");
            }
            TDto seriesDto;
            try
            {
                seriesDto = _mapper.Map<TDto>(series);
                return QResult<TDto>.Ok(seriesDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
