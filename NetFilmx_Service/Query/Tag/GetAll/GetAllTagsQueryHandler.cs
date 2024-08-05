using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetAllTagsQueryHandler<TDto> : IRequestHandler<GetAllTagsQuery<TDto>, QResult<List<TDto>>>
         where TDto : ITagDto
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTagsQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetAllTagsQuery<TDto> query, CancellationToken cancellationToken)
        {

            List<TDto> tagsDto;
            try
            {
                var tags = await _repository.GetAllTagsAsync();
                tagsDto = _mapper.Map<List<TDto>>(tags);
                return QResult<List<TDto>>.Ok(tagsDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }

        }
    }
}
