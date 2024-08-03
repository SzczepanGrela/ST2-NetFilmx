using AutoMapper;
using NetFilmx_Service.Dtos.Like;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class LikeMappingProfile : Profile
    {

        public LikeMappingProfile()
        {
            CreateMap<Like, LikeAddDto>();
            CreateMap<Like, LikeDto>();



        }


    }
}
