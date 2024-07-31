﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.VideoPurchase.GetByUserId
{
    public sealed class GetVideoPurchasesByUserIdQuery<TDto> : IQuery<QResult<TDto>>
    {

        public GetVideoPurchasesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }

    }
}
