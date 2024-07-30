using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetAll
{
    public sealed class GetAllVideoPurchasesQueryHandler<TDto> : IQueryHandler<GetAllVideoPurchasesQuery, QResult<List<TDto>>>
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetAllVideoPurchasesQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetAllVideoPurchasesQuery query)
        {
            
          
            List<TDto> videoPurchasesDto;
            try
            {
                var videoPurchases = _repository.GetAllVideoPurchases();
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
