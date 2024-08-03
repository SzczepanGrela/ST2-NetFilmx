﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByLikeIdQueryHandler<TDto> : IRequestHandler<GetVideoByLikeIdQuery<TDto>, QResult<TDto>>
        where TDto : IVideoDto
    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByLikeIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetVideoByLikeIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var video = await _repository.GetVideoByLikeIdAsync(query.LikeId);
            if (video == null)
            {
                return QResult<TDto>.Fail("Video not found");
            }
            TDto videoDto;
            try
            {
                videoDto = _mapper.Map<TDto>(video);
                return QResult<TDto>.Ok(videoDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }

        }
    }
}
