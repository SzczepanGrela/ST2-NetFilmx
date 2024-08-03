using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.User
{
    public sealed class GetUsersBySeriesIdQueryHandler<TDto> : IRequestHandler<GetUsersBySeriesIdQuery<TDto>, QResult<List<TDto>>>
        where TDto : IUserDto
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
