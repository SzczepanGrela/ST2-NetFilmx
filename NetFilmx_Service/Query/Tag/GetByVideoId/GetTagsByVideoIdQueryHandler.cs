using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetByVideoId
{
    public class GetTagsByVideoIdQueryHandler<TDto> : IQueryHandler<GetTagsByVideoIdQuery<TDto>, List<TDto>>
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
