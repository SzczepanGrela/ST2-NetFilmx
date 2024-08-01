using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Comment
{
    public sealed class AddCommentCommand : IRequest<CResult>
    {       

        public AddCommentCommand(int userId, int videoId, string content)
        {
            UserId = userId;
            VideoId = videoId;
            Content = content;
        }


        public int UserId { get;}

        public int VideoId { get; }

        public string Content { get;}
       
    }
}
