using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetById
{
    public class GetVideoPurchaseByIdQueryHandler<TDto> : IQueryHandler<GetVideoPurchaseByIdQuery, QResult<TDto>>
    {
        private readonly IVideoPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoPurchaseByIdQueryHandler(IVideoPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetVideoPurchaseByIdQuery query)
        {
            var videoPurchase = _repository.GetVideoPurchaseById(query.VideoPurchaseId);
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
