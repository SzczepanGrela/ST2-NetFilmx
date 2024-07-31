using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Video.GetByCategoryId
{
    public sealed class GetVideosByCategoryIdQueryHandler<TDto> : IQueryHandler<GetVideosByCategoryIdQuery<TDto>,List<TDto>>
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideosByCategoryIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetVideosByCategoryIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
            List<TDto> videosDto;
            try
            {
                var videos = await _repository.GetVideosByCategoryIdAsync(query.CategoryId);
                videosDto = _mapper.Map<List<TDto>>(videos);
                return QResult<List<TDto>>.Ok(videosDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
            
        }
    }
}
