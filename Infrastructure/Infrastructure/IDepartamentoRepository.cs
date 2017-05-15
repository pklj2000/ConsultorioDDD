using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;


namespace Consultorio.Data.Infrastructure
{
    public interface IDepartamentoRepository: IRepository<Departamento>
    {
        IEnumerable<Departamento> GetByEmpresa(int empresaId);
    }
}
