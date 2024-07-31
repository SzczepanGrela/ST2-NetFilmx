using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetByUserId
{
    public sealed class GetSeriesPurchasesByUserIdQueryHandler<TDto> : IQueryHandler<GetSeriesPurchasesByUserIdQuery<TDto>, List<TDto>>
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchasesByUserIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetSeriesPurchasesByUserIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            List<TDto> seriesPurchasesDto;
            try
            {
                var seriesPurchases = await _repository.GetSeriesPurchasesByUserIdAsync(query.UserId);
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
