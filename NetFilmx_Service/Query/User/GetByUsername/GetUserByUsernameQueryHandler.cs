using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByUsername
{
    public sealed class GetUserByUsernameQueryHandler<TDto> : IQueryHandler<GetUserByUsernameQuery, QResult<TDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByUsernameQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetUserByUsernameQuery query)
        {
            var user = _repository.GetUserByUsername(query.Username);
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
