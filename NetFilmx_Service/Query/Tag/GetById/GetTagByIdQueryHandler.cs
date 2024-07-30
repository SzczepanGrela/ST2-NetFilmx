using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetById
{
    public sealed class GetTagByIdQueryHandler<TDto> : IQueryHandler<GetTagByIdQuery, QResult<TDto>>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetTagByIdQuery query)
        {
            var tag = _repository.GetTagById(query.TagId);
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
