using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Mappings
{
    public class CommentMappingProfile : Profile
    {

        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDetailsDto>();
            CreateMap<Comment, CommentEditDto>();
            CreateMap<Comment, CommentListDto>();


            CreateMap<CommentEditDto,EditCommentCommand>();
            CreateMap<CommentAddDto, AddCommentCommand>();

        }

    }
}
