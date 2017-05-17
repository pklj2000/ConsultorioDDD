using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(ConsultorioContext context):base(context)
        {
        }
    }
}
