using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.VideoPurchase.GetAll
{
    public sealed class GetAllVideoPurchasesQuery<TDto> : IRequest<QResult<List<TDto>>>  
    {
        public GetAllVideoPurchasesQuery() { }
    }
}
