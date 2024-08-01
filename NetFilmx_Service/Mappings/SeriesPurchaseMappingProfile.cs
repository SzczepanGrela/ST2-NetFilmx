using AutoMapper;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Dtos.Like;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Mappings
{
    public class SeriesPurchaseMappingProfile : Profile
    {

        public SeriesPurchaseMappingProfile()
        {
            CreateMap<SeriesPurchase, SeriesPurchaseAddDto>();
            CreateMap<SeriesPurchase, SeriesPurchaseDetailsDto>();
            CreateMap<SeriesPurchase, SeriesPurchaseDetailsDto>();

            CreateMap<SeriesPurchaseAddDto, AddSeriesPurchaseCommand>();
            
        }


    }
}
