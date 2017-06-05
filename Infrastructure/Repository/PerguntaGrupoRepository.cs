using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Linq;

namespace Consultorio.Data.Repository
{
    class PerguntaGrupoRepository : Repository<PerguntaGrupo>, IPerguntaGrupoRepository
    {
        public PerguntaGrupoRepository(ConsultorioContext context) : base(context)
        {
        }

    }
}
