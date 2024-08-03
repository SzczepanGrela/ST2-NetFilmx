using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideosByExcludedUserIdQueryHandler<TDto> : IRequestHandler<GetVideosByExcludedUserIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IVideoDto
    {

        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideosByExcludedUserIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<QResult<List<TDto>>> Handle(GetVideosByExcludedUserIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            List<TDto> videosDto;
            try
            {
                var videos = await _repository.GetVideosByExcludedUserIdAsync(query.UserId);
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
