using AutoMapper;
using NetFilmx_Service.Query.SeriesPurchase;
using NetFilmx_Storage.Entities;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;
using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Series;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetAllSeriesPurchasesQueryHandler<TDto> : IRequestHandler<GetAllSeriesPurchasesQuery<TDto>, QResult<List<TDto>>>
     where TDto : ISeriesDto
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
