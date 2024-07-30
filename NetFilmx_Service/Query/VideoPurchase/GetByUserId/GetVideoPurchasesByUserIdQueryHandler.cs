using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetByUserId
{
    public sealed class GetVideoPurchasesByUserIdQueryHandler<TDto> : IQueryHandler<GetVideoPurchasesByUserIdQuery, QResult<List<TDto>>>
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoPurchasesByUserIdQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetVideoPurchasesByUserIdQuery query)
        {
          
            List<TDto> videoPurchasesDto;
            try
            {
                var videoPurchases = _repository.GetVideoPurchasesByUserId(query.UserId);

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
