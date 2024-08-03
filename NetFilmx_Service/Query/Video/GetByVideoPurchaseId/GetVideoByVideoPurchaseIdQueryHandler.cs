﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Video
{
    public sealed class GetVideoByVideoPurchaseIdQueryHandler<TDto> : IRequestHandler<GetVideoByVideoPurchaseIdQuery<TDto>, QResult<TDto>>
        where TDto : IVideoDto

    {
        private readonly IVideoRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByVideoPurchaseIdQueryHandler(IVideoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetVideoByVideoPurchaseIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var video = await _repository.GetVideoByVideoPurchaseIdAsync(query.VideoPurchaseId);
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
