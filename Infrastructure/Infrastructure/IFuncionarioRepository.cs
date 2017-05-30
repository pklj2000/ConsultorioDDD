using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IEnumerable<Funcionario> GetByEmpresa(int id);
    }
}
