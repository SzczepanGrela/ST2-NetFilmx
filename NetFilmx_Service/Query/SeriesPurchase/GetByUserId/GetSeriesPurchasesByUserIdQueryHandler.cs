using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Storage.Repositories;

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
