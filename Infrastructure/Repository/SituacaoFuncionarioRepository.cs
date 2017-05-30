using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Repository
{
    public class SituacaoFuncionarioRepository : Repository<SituacaoFuncionario>, ISituacaoFuncionarioRepository
    {
        public SituacaoFuncionarioRepository(ConsultorioContext context) : base(context)
        {
        }
    }
}
