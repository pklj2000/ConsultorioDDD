using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Service.Infrastructure
{
    public interface IDepartamentoService
    {
        IEnumerable<Departamento> GetAll();
        IEnumerable<Departamento> GetByEmpresa(int empresaId);
        Departamento GetById(int id);
        void Insert(Departamento departamento);
        void Delete(int id);
        void Update(Departamento departamento);
        void Save();
    }
}
