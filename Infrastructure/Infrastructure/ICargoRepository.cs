using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        IEnumerable<Cargo> GetByEmpresa(int id);
        IEnumerable<Cargo> GetByDepartamento(int departamentoId);
    }
}
