using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Series;

namespace NetFilmx_Service.Query.SeriesPurchase.GetBySeriesId
{
    public sealed class GetSeriesPurchasesBySeriesIdQueryHandler<TDto> : IRequestHandler<GetSeriesPurchasesBySeriesIdQuery<TDto>, QResult<List<TDto>>>
         where TDto : ISeriesDto
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchasesBySeriesIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetSeriesPurchasesBySeriesIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            
            List<TDto> seriesPurchasesDto;
            try
            {
                var seriesPurchases = await _repository.GetSeriesPurchasesBySeriesIdAsync(query.SeriesId);
                seriesPurchasesDto = _mapper.Map<List<TDto>>(seriesPurchases);
                return QResult<List<TDto>>.Ok(seriesPurchasesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
            
        }
    }
}
