using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetAllVideoPurchasesQueryHandler<TDto> : IRequestHandler<GetAllVideoPurchasesQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoPurchaseDto
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetAllVideoPurchasesQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllVideoPurchasesQuery<TDto> query, CancellationToken cancellationToken)
        {


            List<TDto> videoPurchasesDto;
            try
            {
                var videoPurchases = await _repository.GetAllVideoPurchasesAsync();
                videoPurchasesDto = _mapper.Map<List<TDto>>(videoPurchases);

                return QResult<List<TDto>>.Ok(videoPurchasesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }

        }
    }
}
