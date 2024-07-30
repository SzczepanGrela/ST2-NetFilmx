using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetAll
{
    public sealed class GetAllTagsQueryHandler<TDto> : IQueryHandler<GetAllTagsQuery, QResult<List<TDto>>>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTagsQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetAllTagsQuery query)
        {
            
            List<TDto> tagsDto;
            try
            {
                var tags = _repository.GetAllTags();
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
