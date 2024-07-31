using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.VideoPurchase;

namespace NetFilmx_Service.Query.VideoPurchase.GetAll
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
                var videoPurchases =await _repository.GetAllVideoPurchasesAsync();
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
