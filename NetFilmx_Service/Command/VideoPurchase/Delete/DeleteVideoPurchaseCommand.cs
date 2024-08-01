using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public class DeleteVideoPurchaseCommand : IRequest<CResult>
    {


        public DeleteVideoPurchaseCommand(int videoId, int userId)
        {
            VideoId = videoId;

            UserId = userId;
        }

        public int VideoId { get; }

        public int UserId { get;  }

      
    }
}
