using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    public class RiscoRepository : Repository<Risco>, IRiscoRepository
    {
        public RiscoRepository(ConsultorioContext context) : base(context)
        {
        }

        public override void Insert(Risco entity)
        {
            entity.Validate();
            base.Insert(entity);
        }
    }
}
