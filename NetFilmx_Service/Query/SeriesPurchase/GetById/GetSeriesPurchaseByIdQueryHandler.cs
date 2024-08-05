using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchaseByIdQueryHandler<TDto> : IRequestHandler<GetSeriesPurchaseByIdQuery<TDto>, QResult<TDto>>
    where TDto : ISeriesPurchaseDto
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
