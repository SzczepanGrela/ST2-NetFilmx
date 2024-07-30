using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetAll
{
    public sealed class GetAllUsersQueryHandler<TDto> : IQueryHandler<GetAllUsersQuery, QResult<List<TDto>>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<List<TDto>> Handle(GetAllUsersQuery query)
        {
            
          
            List<TDto> usersDto;
            try
            {
                var users = _repository.GetAllUsers();
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
