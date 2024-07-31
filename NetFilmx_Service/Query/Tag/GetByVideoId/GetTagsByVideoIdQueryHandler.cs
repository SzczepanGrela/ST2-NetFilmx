using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Tag;

namespace NetFilmx_Service.Query.Tag
{
    public class GetTagsByVideoIdQueryHandler<TDto> : IRequestHandler<GetTagsByVideoIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : ITagDto
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagsByVideoIdQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetTagsByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            List<TDto> tagsDto;
            try
            {
                var tags = await _repository.GetTagsByVideoIdAsync(query.VideoId);
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
