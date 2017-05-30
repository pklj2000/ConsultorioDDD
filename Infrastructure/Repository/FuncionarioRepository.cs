using System;
using System.Collections.Generic;
using Consultorio.Data.Context;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ConsultorioContext context) : base(context)
        {
        }

        public override Funcionario GetById(int id)
        {
            Funcionario _funcionario = Context.Funcionario
                .Include("Empresa")
                .Include("Departamento")
                .Include("Cargo")
                .Include("EstadoCivil")
                .Include("Periodicidade")
                .Include("SituacaoFuncionario")
                .FirstOrDefault(x => x.Id == id);

            return _funcionario;
        }

        public IEnumerable<Funcionario> GetByEmpresa(int id)
        {
            return Context.Funcionario
                .Include("Empresa")
                .Include("Departamento")
                .Include("Cargo")
                .Include("SituacaoFuncionario")
                .Where(x => x.EmpresaId == id).ToList();
        }
    }
}
