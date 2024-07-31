using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetFilmx_Service.Dtos.Video;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByCategoryIdQueryHandler<TDto> : IRequestHandler<GetVideosByCategoryIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoDto
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
