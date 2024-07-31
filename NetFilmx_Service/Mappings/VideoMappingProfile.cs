using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class VideoMappingProfile : Profile
    {

        public VideoMappingProfile()
        {
            CreateMap<Video, VideoListDto>();
            CreateMap<Video, VideoDetailsDto>();
            CreateMap<Video, VideoAddDto>();
            CreateMap<Video, VideoEditDto>();

            CreateMap<VideoEditDto, EditVideoCommand>();
            CreateMap<VideoAddDto, AddVideoCommand>();
        
        }


    }
}
