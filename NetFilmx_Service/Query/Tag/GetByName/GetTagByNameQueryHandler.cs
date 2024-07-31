using AutoMapper;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Tag.GetByName
{
    public class GetTagByNameQueryHandler<TDto> : IRequestHandler<GetTagByNameQuery<TDto>, QResult<TDto>>
        where TDto : ITagDto
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagByNameQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetTagByNameQuery<TDto> query, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetTagByNameAsync(query.TagName);
            if (tag == null)
            {
                return QResult<TDto>.Fail("Tag not found");
            }
            TDto tagDto;
            try
            {
                tagDto = _mapper.Map<TDto>(tag);
                return QResult<TDto>.Ok(tagDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
