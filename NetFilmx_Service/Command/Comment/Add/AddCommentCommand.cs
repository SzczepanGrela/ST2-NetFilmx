using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.Comment.Add
{
    public sealed class AddCommentCommand : ICommand
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
