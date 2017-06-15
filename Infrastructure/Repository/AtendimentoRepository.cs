using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class AtendimentoRepository : Repository<Atendimento>, IAtendimentoRepository
    {
        public AtendimentoRepository(ConsultorioContext context) : base(context)
        {
            
        }
        public override IEnumerable<Atendimento> GetAll()
        {
            return Context.Atendimentos.Include("Empresa").Include("Funcionario").Include("TipoExame").ToList();
        }
        public override Atendimento GetById(int id)
        {
            return Context.Atendimentos.Include("Empresa").Include("Funcionario").Include("TipoExame").FirstOrDefault(x => x.Id == id);
        }
    }
}
