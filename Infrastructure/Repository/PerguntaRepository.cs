using System;
using System.Collections.Generic;
using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class PerguntaRepository : Repository<Pergunta>, IPerguntaRepository
    {
        public PerguntaRepository(ConsultorioContext context) : base(context)
        {
        }

        public ICollection<Pergunta> GetByGrupo(int grupoId)
        {
            return Context.Pergunta.Where(x => x.PerguntaGrupoId == grupoId).ToList();
        }
    }
}
