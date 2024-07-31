using AutoMapper;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUserByLikeIdQueryHandler<TDto> : IRequestHandler<GetUserByLikeIdQuery<TDto>, QResult<TDto>>
        where TDto : IUserDto
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByLikeIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<TDto>> Handle(GetUserByLikeIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByLikeIdAsync(query.LikeId);
            if (user == null)
            {
                return QResult<TDto>.Fail("User not found");
            }
            TDto userDto;
            try
            {
                userDto = _mapper.Map<TDto>(user);
                return QResult<TDto>.Ok(userDto);
            }
            catch (Exception ex)
            {
                return QResult<TDto>.Fail(ex.Message);
            }
            
        }
    }
}
