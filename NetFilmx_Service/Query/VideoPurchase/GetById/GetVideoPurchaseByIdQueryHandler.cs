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

namespace NetFilmx_Service.Query.VideoPurchase
{
    public class GetVideoPurchaseByIdQueryHandler<TDto> : IRequestHandler<GetVideoPurchaseByIdQuery<TDto>, QResult<TDto>>
        where TDto : IVideoPurchaseDto
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoPurchaseByIdQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetVideoPurchaseByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var videoPurchase = await _repository.GetVideoPurchaseByIdAsync(query.VideoPurchaseId);
            if (videoPurchase == null)
            {
                return QResult<TDto>.Fail("Video purchase not found");
            }
            TDto videoPurchaseDto;
            try
            {
                videoPurchaseDto = _mapper.Map<TDto>(videoPurchase);
                return QResult<TDto>.Ok(videoPurchaseDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
           
        }
    }
}
