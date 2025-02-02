﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.VideoPurchase
{
    public class GetVideoPurchasesByVideoIdQueryHandler<TDto> : IRequestHandler<GetVideoPurchasesByVideoIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoPurchaseDto
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
