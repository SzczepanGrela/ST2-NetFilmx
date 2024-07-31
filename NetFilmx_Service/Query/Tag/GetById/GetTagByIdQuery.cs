﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetById
{
    public sealed class GetTagByIdQuery<TDto> : IQuery<TDto>
    {
        public GetTagByIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
