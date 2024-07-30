using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetBySeriesPurchaseId
{
    public sealed class GetUserBySeriesPurchaseIdQueryHandler<TDto> : IQueryHandler<GetUserBySeriesPurchaseIdQuery, QResult<TDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserBySeriesPurchaseIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetUserBySeriesPurchaseIdQuery query)
        {
            var user = _repository.GetUserBySeriesPurchaseId(query.SeriesPurchaseId);
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
