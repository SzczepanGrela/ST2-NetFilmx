using AutoMapper;
using NetFilmx_Service.Query.SeriesPurchase.GetByUserId;
using NetFilmx_Storage.Entities;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;
using AutoMapper;

namespace NetFilmx_Service.Query.SeriesPurchase.GetAll
{
    public sealed class GetAllSeriesPurchasesQueryHandler<TDto> : IQueryHandler<GetAllSeriesPurchasesQuery<TDto>, List<TDto>>
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;
        

        public GetAllSeriesPurchasesQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
           
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllSeriesPurchasesQuery<TDto> query, CancellationToken cancellationToken)
        {


            List<TDto> seriesPurchasesDto;
            try
            {
                var seriesPurchases = await _repository.GetAllSeriesPurchasesAsync();
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
