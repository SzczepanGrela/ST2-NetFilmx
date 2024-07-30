using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Series.GetById
{
    public sealed class GetSeriesByIdQueryHandler<TDto> : IQueryHandler<GetSeriesByIdQuery, QResult<TDto>>
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByIdQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetSeriesByIdQuery query)
        {
            var series = _repository.GetSeriesById(query.SeriesId);
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
