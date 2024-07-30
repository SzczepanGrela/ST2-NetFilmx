using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetBySeriesId
{
    public sealed class GetSeriesPurchasesBySeriesIdQueryHandler<TDto> : IQueryHandler<GetSeriesPurchasesBySeriesIdQuery, QResult<List<TDto>>>
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchasesBySeriesIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetSeriesPurchasesBySeriesIdQuery query)
        {
            
            
            List<TDto> seriesPurchasesDto;
            try
            {
                var seriesPurchases = _repository.GetSeriesPurchasesBySeriesId(query.SeriesId);
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
