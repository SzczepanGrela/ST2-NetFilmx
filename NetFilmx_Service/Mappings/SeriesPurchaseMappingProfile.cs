using AutoMapper;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Storage.Entities;

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
