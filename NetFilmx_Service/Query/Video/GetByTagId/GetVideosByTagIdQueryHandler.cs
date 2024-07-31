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
    public sealed class GetVideosByTagIdQueryHandler<TDto> : IRequestHandler<GetVideosByTagIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoDto
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideosByTagIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetVideosByTagIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            
           
            List<TDto> videosDto;
            try
            {
                var videos = await _repository.GetVideosByTagIdAsync(query.TagId);
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
