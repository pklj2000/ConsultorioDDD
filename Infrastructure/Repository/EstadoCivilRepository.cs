using System;
using System.Collections.Generic;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class EstadoCivilRepository : Repository<EstadoCivil>, IEstadoCivilRepository
    {
        public EstadoCivilRepository(ConsultorioContext context):base(context)
        {
        }

       
    }
}
