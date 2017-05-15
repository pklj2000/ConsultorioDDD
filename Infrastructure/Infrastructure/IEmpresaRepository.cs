using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Infrastructure
{
    public interface IEmpresaRepository: IRepository<Empresa>
    {
        IEnumerable<Empresa> GetByNome(string nome);
    }
}
