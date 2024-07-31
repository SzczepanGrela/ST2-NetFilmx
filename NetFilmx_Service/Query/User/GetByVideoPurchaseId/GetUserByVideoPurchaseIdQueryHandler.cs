using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByVideoPurchaseId
{
    public sealed class GetUserByVideoPurchaseIdQueryHandler<TDto> : IQueryHandler<GetUserByVideoPurchaseIdQuery<TDto>, TDto>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByVideoPurchaseIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task<QResult<TDto>> Handle(GetUserByVideoPurchaseIdQuery<TDto> query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByVideoPurchaseIdAsync(query.VideoPurchaseId);
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
