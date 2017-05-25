using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    class PeriodicidadeRepository : Repository<Periodicidade>, IPeriodicidadeRepository
    {
        public PeriodicidadeRepository(ConsultorioContext context) : base(context)
        {
        }
    }
}
