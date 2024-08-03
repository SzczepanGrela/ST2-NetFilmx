using AutoMapper;
using NetFilmx_Service.Command.User;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class UserMappingProfile : Profile
    {

        public UserMappingProfile()
        {

            CreateMap<User, UserListDto>();
            CreateMap<User, UserEditDto>();
            CreateMap<User, UserAddDto>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<User, UserPasswordDto>();

            CreateMap<UserEditDto, EditUserCommand>();
            CreateMap<UserPasswordDto, NewPasswordCommand>();
            CreateMap<UserAddDto, AddUserCommand>();
        }


    }
}
