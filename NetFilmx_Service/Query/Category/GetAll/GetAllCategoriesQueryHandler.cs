﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetAllCategoriesQueryHandler<TDto> : IRequestHandler<GetAllCategoriesQuery<TDto>, QResult<List<TDto>>>
        where TDto : ICategoryDto // : IRequestHandler<GetAllCategoriesQuery<TDto>, List<TDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllCategoriesQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> categoryDtos;
            try
            {
                var categories = await _repository.GetAllCategoriesAsync();
                categoryDtos = _mapper.Map<List<TDto>>(categories);
                return QResult<List<TDto>>.Ok(categoryDtos);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
