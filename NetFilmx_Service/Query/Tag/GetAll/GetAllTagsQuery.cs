﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Tag.GetAll
{
    public sealed class GetAllTagsQuery<TDto> : IQuery<List<TDto>>
    {
        
        public GetAllTagsQuery() { }
    }
}
