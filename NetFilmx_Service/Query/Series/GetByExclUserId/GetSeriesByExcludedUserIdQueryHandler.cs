﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Series
{
    public sealed class GetSeriesByExcludedUserIdQueryHandler<TDto> : IRequestHandler<GetSeriesByExcludedUserIdQuery<TDto>, QResult<List<TDto>>>
    where TDto : ISeriesDto
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByExcludedUserIdQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetSeriesByExcludedUserIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var series = await _repository.GetSeriesByExcludedUserIdAsync(query.UserId);
            if (series == null)
            {
                return QResult<List<TDto>>.Fail("Series not found");
            }

            List<TDto> seriesDto;
            try
            {
                seriesDto = _mapper.Map<List<TDto>>(series);
                return QResult<List<TDto>>.Ok(seriesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
