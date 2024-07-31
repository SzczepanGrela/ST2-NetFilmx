using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Series.GetByVideoId
{
    public sealed class GetSeriesByVideoIdQueryHandler<TDto>: IRequestHandler<GetSeriesByVideoIdQuery<TDto>, QResult<List<TDto>>>
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByVideoIdQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetSeriesByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            List<TDto> seriesDto;
            try
            {
                var series = await _repository.GetSeriesByVideoIdAsync(query.VideoId);
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
