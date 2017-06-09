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

        public override Pergunta GetById(int id)
        {
            var _pergunta = Context.Pergunta.Include("PerguntaGrupo").FirstOrDefault(x => x.Id == id);
            var _tipoPergunta = new TipoPergunta().TiposPergunta[_pergunta.TipoRespostaId];

            _pergunta.TipoResposta = new Dictionary<int, string>();
            _pergunta.TipoResposta.Add(_pergunta.TipoRespostaId, _tipoPergunta);
            return _pergunta;
        }
    }
}
