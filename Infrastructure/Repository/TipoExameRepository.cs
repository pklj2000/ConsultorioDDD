using Consultorio.Data.Infrastructure;
using System;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class TipoExameRepository : Repository<TipoExame>, ITipoExameRepository
    {
        public TipoExameRepository(ConsultorioContext context) : base(context)
        {
        }
    }
}
