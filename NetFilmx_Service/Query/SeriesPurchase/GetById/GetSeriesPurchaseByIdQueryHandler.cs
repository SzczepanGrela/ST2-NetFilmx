using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.SeriesPurchase.GetById
{
    public sealed class GetSeriesPurchaseByIdQueryHandler<TDto> : IQueryHandler<GetSeriesPurchaseByIdQuery<TDto>, TDto>
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchaseByIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetSeriesPurchaseByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var seriesPurchase = await _repository.GetSeriesPurchaseByIdAsync(query.SeriesPurchaseId);
            if (seriesPurchase == null)
            {
                return QResult<TDto>.Fail("Series purchase not found");
            }
            TDto seriesPurchaseDto;
            try
            {
                seriesPurchaseDto = _mapper.Map<TDto>(seriesPurchase);
                return QResult<TDto>.Ok(seriesPurchaseDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
