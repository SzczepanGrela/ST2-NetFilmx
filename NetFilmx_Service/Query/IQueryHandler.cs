using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetFilmx_Service.Query
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }

}
