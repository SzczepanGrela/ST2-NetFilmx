﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagByIdQueryHandler<TDto> : IRequestHandler<GetTagByIdQuery<TDto>, QResult<TDto>>
        where TDto : ITagDto
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetTagByIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetTagByIdAsync(query.TagId);
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
