using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetBySeriesId
{
    public sealed class GetUsersBySeriesIdQueryHandler<TDto> : IQueryHandler<GetUsersBySeriesIdQuery<TDto>, List<TDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersBySeriesIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QResult<List<TDto>>> Handle(GetUsersBySeriesIdQuery<TDto> query, CancellationToken cancellationToken)
        {
          
            List<TDto> usersDto;
            try
            {
                var users = await _repository.GetUsersBySeriesIdAsync(query.SeriesId);
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
