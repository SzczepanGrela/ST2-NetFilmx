using AutoMapper;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Series.GetByName
{
    public sealed class GetSeriesByNameQueryHandler<TDto> : IRequestHandler<GetSeriesByNameQuery<TDto>, QResult<TDto>>
         where TDto : ISeriesDto
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByNameQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetSeriesByNameQuery<TDto> query, CancellationToken cancellationToken)
        {
            var series = await _repository.GetSeriesByNameAsync(query.SeriesName);
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
