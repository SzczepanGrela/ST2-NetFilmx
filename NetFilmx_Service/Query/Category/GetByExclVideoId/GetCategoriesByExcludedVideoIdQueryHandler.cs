using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoriesByExcludedVideoIdQueryHandler<TDto> : IRequestHandler<GetCategoriesByExcludedVideoIdQuery<TDto>, QResult<List<TDto>>>
    where TDto : ICategoryDto
        
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriesByExcludedVideoIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<QResult<List<TDto>>> Handle(GetCategoriesByExcludedVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {

            var category = await _repository.GetCategoriesByExcludedVideoIdAsync(query.VideoId);
            if (category == null)
            {
                return QResult<List<TDto>>.Fail("Category not found");
            }

            List<TDto> categoryDto;
            try
            {
                categoryDto = _mapper.Map<List<TDto>>(category);
                return QResult<List<TDto>>.Ok(categoryDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }





    }
}
