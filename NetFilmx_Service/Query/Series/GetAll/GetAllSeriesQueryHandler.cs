using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Series;

namespace NetFilmx_Service.Query.Series.GetAll
{
    public sealed class GetAllSeriesQueryHandler<TDto> : IRequestHandler<GetAllSeriesQuery<TDto>, QResult<List<TDto>>>
        where TDto : ISeriesDto
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllSeriesQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> seriesDto;
            try
            {
                var series = await _repository.GetAllSeriesAsync();
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
