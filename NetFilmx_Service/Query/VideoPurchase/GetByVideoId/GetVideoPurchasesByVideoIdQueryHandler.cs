using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetByVideoId
{
    public class GetVideoPurchasesByVideoIdQueryHandler<TDto> : IQueryHandler<GetVideoPurchasesByVideoIdQuery<TDto>, List<TDto>>
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoPurchasesByVideoIdQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetVideoPurchasesByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            
            List<TDto> videoPurchasesDto;
            try
            {
                var videoPurchases = await _repository.GetVideoPurchasesByVideoIdAsync(query.VideoId);
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
