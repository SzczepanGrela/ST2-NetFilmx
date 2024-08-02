using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersByExcludedVideoIdQueryHandler<TDto> : IRequestHandler<GetUsersByExcludedVideoIdQuery<TDto>, QResult<List<TDto>>>
    where TDto : IUserDto
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersByExcludedVideoIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetUsersByExcludedVideoIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsersByExcludedVideoIdAsync(query.VideoId);
            if (users == null)
            {
                return QResult<List<TDto>>.Fail("Users not found");
            }

            List<TDto> userDtos;
            try
            {
                userDtos = _mapper.Map<List<TDto>>(users);
                return QResult<List<TDto>>.Ok(userDtos);
            }
            catch (Exception ex)
            {
                return QResult<List<TDto>>.Fail(ex.Message);
            }
        }
    }
}
