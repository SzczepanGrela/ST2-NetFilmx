using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Dtos.Category;
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
