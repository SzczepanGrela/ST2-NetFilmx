﻿using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersByVideoIdQueryHandler<TDto> : IRequestHandler<GetUsersByVideoIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IUserDto
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersByVideoIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetUsersByVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {


            List<TDto> usersDto;
            try
            {
                var users = await _repository.GetUsersByVideoIdAsync(query.VideoId);
                usersDto = _mapper.Map<List<TDto>>(users);
                return QResult<List<TDto>>.Ok(usersDto);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }

        }
    }
}
