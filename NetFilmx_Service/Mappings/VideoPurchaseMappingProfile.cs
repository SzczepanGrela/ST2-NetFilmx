using AutoMapper;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class VideoPurchaseMappingProfile : Profile
    {

        public VideoPurchaseMappingProfile()
        {
            CreateMap<VideoPurchase, VideoPurchaseAddDto>();
            CreateMap<VideoPurchase, VideoPurchaseDetailsDto>();
            CreateMap<VideoPurchase, VideoPurchaseDetailsDto>();

            CreateMap<VideoPurchaseAddDto, AddVideoPurchaseCommand>();

        }


    }
}
