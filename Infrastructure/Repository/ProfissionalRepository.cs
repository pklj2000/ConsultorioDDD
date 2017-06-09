using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Repository
{
    public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
    {
        public ProfissionalRepository(ConsultorioContext context) : base(context)
        {
        }
    }
}
