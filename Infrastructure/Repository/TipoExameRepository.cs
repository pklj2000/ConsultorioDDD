using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    public class TipoExameRepository : Repository<TipoExame>, ITipoExameRepository
    {
        public TipoExameRepository(ConsultorioContext context) : base(context)
        {
        }

    
    }
}
