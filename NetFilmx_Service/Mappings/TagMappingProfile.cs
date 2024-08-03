using AutoMapper;
using NetFilmx_Service.Command.Tag;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class TagMappingProfile : Profile
    {

        public TagMappingProfile()
        {

            CreateMap<Tag, TagDetailsDto>();
            CreateMap<Tag, TagAddDto>();
            CreateMap<Tag, TagEditDto>();
            CreateMap<Tag, TagListDto>();

            CreateMap<TagEditDto, EditTagCommand>();
            CreateMap<TagAddDto, AddTagCommand>();


        }


    }
}
