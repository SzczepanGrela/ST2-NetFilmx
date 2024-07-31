using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.VideoPurchase;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public sealed class GetVideoPurchasesByUserIdQueryHandler<TDto> : IRequestHandler<GetVideoPurchasesByUserIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoPurchaseDto
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoPurchasesByUserIdQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetVideoPurchasesByUserIdQuery<TDto> query, CancellationToken cancellationToken)
        {
          
            List<TDto> videoPurchasesDto;
            try
            {
                var videoPurchases = await _repository.GetVideoPurchasesByUserIdAsync(query.UserId);

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
