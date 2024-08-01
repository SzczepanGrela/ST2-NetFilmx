using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.SeriesPurchase;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchasesByUserIdQueryHandler<TDto> : IRequestHandler<GetSeriesPurchasesByUserIdQuery<TDto>, QResult<List<TDto>>>
            where TDto : ISeriesPurchaseDto
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
