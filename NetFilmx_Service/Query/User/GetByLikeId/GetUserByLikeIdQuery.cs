﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.User.GetByLikeId
{
    public sealed class GetUserByLikeIdQuery : IQuery
    {
        public GetUserByLikeIdQuery(int likeId)
        {
            LikeId = likeId;
        }
        public int LikeId { get; }
    }
}
