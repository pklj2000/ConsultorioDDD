using System;
using System.Collections.Generic;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(ConsultorioContext context) : base(context)
        {
        }

        public IEnumerable<Departamento> GetByEmpresa(int empresaId)
        {
            return this.Find(x => x.EmpresaId == empresaId, o=>o.Descricao);
        }
    }
}
