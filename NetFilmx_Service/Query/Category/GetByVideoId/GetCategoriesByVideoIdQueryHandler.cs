using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoriesByVideoIdQueryHandler<TDto> : IRequestHandler<GetCategoriesByVideoIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : ICategoryDto
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriesByVideoIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetCategoriesByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> categoriesDto;
            try
            {
                var categories = await _repository.GetCategoriesByVideoIdAsync(query.VideoId);
                categoriesDto = _mapper.Map<List<TDto>>(categories);
                return QResult<List<TDto>>.Ok(categoriesDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
