using AutoMapper;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
