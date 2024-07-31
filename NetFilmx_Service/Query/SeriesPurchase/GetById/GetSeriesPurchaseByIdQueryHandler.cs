using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Series;

namespace NetFilmx_Service.Query.SeriesPurchase
{
    public sealed class GetSeriesPurchaseByIdQueryHandler<TDto> : IRequestHandler<GetSeriesPurchaseByIdQuery<TDto>, QResult<TDto>>
    where TDto : ISeriesDto
    {
        private readonly ISeriesPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesPurchaseByIdQueryHandler(ISeriesPurchaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetSeriesPurchaseByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var seriesPurchase = await _repository.GetSeriesPurchaseByIdAsync(query.SeriesPurchaseId);
            if (seriesPurchase == null)
            {
                return QResult<TDto>.Fail("Series purchase not found");
            }
            TDto seriesPurchaseDto;
            try
            {
                seriesPurchaseDto = _mapper.Map<TDto>(seriesPurchase);
                return QResult<TDto>.Ok(seriesPurchaseDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
