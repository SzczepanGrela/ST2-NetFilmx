using AutoMapper;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByCommentId
{
    public sealed class GetUserByCommentIdQueryHandler<TDto> : IQueryHandler<GetUserByCommentIdQuery, QResult<TDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByCommentIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public QResult<TDto> Handle(GetUserByCommentIdQuery query)
        {
            var user = _repository.GetUserByCommentId(query.CommentId);
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
