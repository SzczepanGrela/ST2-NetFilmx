using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetByUserId
{
    public sealed class GetSeriesPurchasesByUserIdQueryHandler<TDto> : IQueryHandler<GetSeriesPurchasesByUserIdQuery, QResult<List<TDto>>>
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchasesByUserIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetSeriesPurchasesByUserIdQuery query)
        {
            
            List<TDto> seriesPurchasesDto;
            try
            {
                var seriesPurchases = _repository.GetSeriesPurchasesByUserId(query.UserId);
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
